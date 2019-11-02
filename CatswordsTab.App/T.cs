using CatswordsTab.App.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CatswordsTab.App
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
                new LocalizationModel { MsgId = "CatswordsTabWelcome", MsgStr = "캐츠워즈 탭 : 주의사항" },
                new LocalizationModel { MsgId = "CatswordsTabMain", MsgStr = "캐츠워즈 탭 : 커뮤니티" },
                new LocalizationModel { MsgId = "CatswordsTabWriter", MsgStr = "캐츠워즈 탭 : 의견작성" },
                new LocalizationModel { MsgId = "CatswordsTabExpert", MsgStr = "캐츠워즈 탭 : 전문가" },
                new LocalizationModel { MsgId = "CatswordsTabSolver", MsgStr = "캐츠워즈 탭 : 암호해제기" },
                new LocalizationModel { MsgId = "CatswordsTabApplication", MsgStr = "캐츠워즈 탭 : 설치된 프로그램" },
                new LocalizationModel { MsgId = "CatswordsTabAssociation", MsgStr = "캐츠워즈 탭 : 연결 프로그램" },
                new LocalizationModel { MsgId = "Caution", MsgStr = "주의사항" },
                new LocalizationModel { MsgId = "Agree", MsgStr = "동의" },
                new LocalizationModel { MsgId = "Agree", MsgStr = "동의" },
                new LocalizationModel { MsgId = "Choose your file...", MsgStr = "파일을 선택하여 주세요..." },
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
                new LocalizationModel { MsgId = "Expert", MsgStr = "전문가" },
                new LocalizationModel {
                    MsgId = "This program does not guarantee the accuracy of the data. The use of this program is at your sole discretion and responsibility",
                    MsgStr = "이 프로그램은 데이터의 정확성을 보증하지 않습니다. 이 프로그램을 사용함에 따른 판단과 책임을 전적으로 사용자에게 있습니다."
                },
                new LocalizationModel { MsgId = "Tools", MsgStr = "도구" },
                new LocalizationModel { MsgId = "Experiments", MsgStr = "실험적 기능" },
                new LocalizationModel { MsgId = "Manifest file", MsgStr = "해제 절차서" },
                new LocalizationModel { MsgId = "Solver", MsgStr = "암호해제기" },
                new LocalizationModel { MsgId = "Solve", MsgStr = "해제" },
                new LocalizationModel { MsgId = "Export to", MsgStr = "내보낼 경로" },
                new LocalizationModel { MsgId = "Choose...", MsgStr = "선택..." },
                new LocalizationModel { MsgId = "Open protection solver...", MsgStr = "암호해제기 열기..." },
                new LocalizationModel { MsgId = "View installed applications...", MsgStr = "설치된 프로그램 보기..." },
                new LocalizationModel { MsgId = "OK", MsgStr = "확인" },
                new LocalizationModel { MsgId = "Submit", MsgStr = "제출" },
                new LocalizationModel { MsgId = "Applications", MsgStr = "어플리케이션" },
                new LocalizationModel { MsgId = "View file associations...", MsgStr = "연결 프로그램 보기..." },
                new LocalizationModel { MsgId = "Associations", MsgStr = "연결 프로그램" },
                new LocalizationModel { MsgId = "Done", MsgStr = "완료" },
                new LocalizationModel { MsgId = "Choose...", MsgStr = "선택..." },
                new LocalizationModel { MsgId = "Download manifest file (Solver)...", MsgStr = "해제 절차서 내려받기..." }
            };

            // add English translation
            translation["en"] = new List<LocalizationModel>
            {
                new LocalizationModel { MsgId = "CatswordsTabWelcome", MsgStr = "CatswordsTab: Caution" },
                new LocalizationModel { MsgId = "CatswordsTabMain", MsgStr = "CatswordsTab: Community" },
                new LocalizationModel { MsgId = "CatswordsTabWriter", MsgStr = "CatswordsTab: Writer" },
                new LocalizationModel { MsgId = "CatswordsTabExpert", MsgStr = "CatswordsTab: Expert" },
                new LocalizationModel { MsgId = "CatswordsTabSolver", MsgStr = "CatswordsTab: Solver" },
                new LocalizationModel { MsgId = "CatswordsTabApplication", MsgStr = "CatswordsTab: Installed applications" },
                new LocalizationModel { MsgId = "CatswordsTabAssociation", MsgStr = "CatswordsTab: File Associations" }
            };
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
