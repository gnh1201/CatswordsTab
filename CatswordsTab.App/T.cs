using CatswordsTab.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatswordsTab.App
{
    class T
    {
        public static Dictionary<string, List<LocalizationModel>> Translation;
        static T()
        {
            Translation = new Dictionary<string, List<LocalizationModel>>();

            // add Korean translation
            List<LocalizationModel> ko = new List<LocalizationModel> {
                new LocalizationModel { MsgId = "CatswordsTabMain", MsgStr = "캐츠워즈 탭 : 커뮤니티" },
                new LocalizationModel { MsgId = "CatswordsTabWriter", MsgStr = "캐츠워즈 탭 : 의견작성" },
                new LocalizationModel { MsgId = "CatswordsTabExpert", MsgStr = "캐츠워즈 탭 : 전문가" },
                new LocalizationModel { MsgId = "Community", MsgStr = "커뮤니티" },
                new LocalizationModel { MsgId = "Please check your internet connection", MsgStr = "인터넷 연결이 원활하지 않으니 확인 바랍니다" },
                new LocalizationModel { MsgId = "Comment", MsgStr = "의견작성" },
                new LocalizationModel { MsgId = "Contribute this project", MsgStr = "이 프로젝트에 기여" },
                new LocalizationModel { MsgId = "Summary", MsgStr = "요약" },
                new LocalizationModel { MsgId = "Send", MsgStr = "보내기" },
                new LocalizationModel { MsgId = "HexView", MsgStr = "16진수" },
                new LocalizationModel { MsgId = "Message:", MsgStr = "의견 :" },
                new LocalizationModel { MsgId = "Reply email (optional):", MsgStr = "회신 전자우편 (선택) :" },
                new LocalizationModel { MsgId = "I accept the Terms and Conditions and Privacy Policy", MsgStr = "이용약관 및 개인정보보호정책에 동의합니다" },
                new LocalizationModel { MsgId = "You must accept to the Terms and Conditions and Privacy Policy", MsgStr = "이용약관 및 개인정보보호정책에 동의하여야 합니다" },
                new LocalizationModel { MsgId = "Expert", MsgStr = "전문가" }
            };
            Translation["ko"] = ko;

            // add English translation
            List<LocalizationModel> en = new List<LocalizationModel>
            {
                new LocalizationModel { MsgId = "CatswordsTabWelcome", MsgStr = "CatswordsTab: Caution" },
                new LocalizationModel { MsgId = "CatswordsTabMain", MsgStr = "CatswordsTab: Community" },
                new LocalizationModel { MsgId = "CatswordsTabWriter", MsgStr = "CatswordsTab: Writer" },
                new LocalizationModel { MsgId = "CatswordsTabExpert", MsgStr = "CatswordsTab: Expert" }
            };
            Translation["en"] = en;
        }

        public static string _(string MsgId, string Locale = "en")
        {
            if (Translation.ContainsKey(Locale))
            {
                List<LocalizationModel> localizations = Translation[Locale];
                try
                {
                    LocalizationModel result = localizations.First(x => x.MsgId == MsgId);
                    return result.MsgStr;
                }
                catch (Exception)
                {
                    return MsgId;
                }
            }
            else
            {
                return MsgId;
            }
        }
    }
}
