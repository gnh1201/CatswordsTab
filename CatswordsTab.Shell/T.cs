using CatswordsTab.Shell.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CatswordsTab.Shell
{
    class T
    {
        private static Dictionary<string, List<LocalizationModel>> translation;
        private static string locale;

        static T()
        {
            // initialize translation
            SetTranslation(new Dictionary<string, List<LocalizationModel>>());
            SetLocale(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);

            // add Korean translation
            translation["ko"] = new List<LocalizationModel> {
                new LocalizationModel { MsgId = "Community", MsgStr = "커뮤니티" },
                new LocalizationModel { MsgId = "Detail", MsgStr = "자세히" },
                new LocalizationModel {
                    MsgId = "You have to set path of CatswordsTab.App.exe in order to view details",
                    MsgStr = "자세한 정보를 보려면 CatswordsTab.App.exe 파일의 경로를 설정하여 주세요"
                },
                new LocalizationModel { MsgId = "Unknown error", MsgStr = "알 수 없는 오류" }
            };

            // add English translation
            translation["en"] = new List<LocalizationModel>();
        }

        public static void SetTranslation(Dictionary<string, List<LocalizationModel>> t)
        {
            translation = t;
        }

        public static void SetLocale(string s)
        {
            locale = s;
        }

        public static string GetLocale()
        {
            return locale;
        }

        public static string _(string msgId)
        {
            if (translation.ContainsKey(locale))
            {
                List<LocalizationModel> localizations = translation[locale];
                try
                {
                    LocalizationModel result = localizations.First(x => x.MsgId == msgId);
                    return result.MsgStr;
                }
                catch (Exception)
                {
                    return msgId;
                }
            }
            else
            {
                return msgId;
            }
        }
    }
}
