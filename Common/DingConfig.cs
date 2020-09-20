using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DingConfig
    {
        //企业CorpID
        private static string _ECorpId;

        //企业CorpSecret
        private static string _ECorpSecret;

        //具体应用的appId
        private static string _EAgentID;


        //当前网站的weburl
        private static string _webUrl;


        //isv参数
        private static string _SUITE_KEY;



        private static string _SUITE_KEY_SECRET;


        private static string _ENCODING_AES_KEY;


        private static string _Token;


        public static string ECorpId
        {
            get { return DingConfig._ECorpId; }
            set { DingConfig._ECorpId = value; }
        }

        public static string ECorpSecret
        {
            get { return DingConfig._ECorpSecret; }
            set { DingConfig._ECorpSecret = value; }
        }


        public static string EAgentID
        {
            get { return DingConfig._EAgentID; }
            set { DingConfig._EAgentID = value; }
        }

        public static string WebUrl
        {
            get { return DingConfig._webUrl; }
            set { DingConfig._webUrl = value; }
        }

        public static string SUITE_KEY
        {
            get { return DingConfig._SUITE_KEY; }
            set { DingConfig._SUITE_KEY = value; }
        }

        public static string SUITE_KEY_SECRET
        {
            get { return DingConfig._SUITE_KEY_SECRET; }
            set { DingConfig._SUITE_KEY_SECRET = value; }
        }

        public static string Token
        {
            get { return DingConfig._Token; }
            set { DingConfig._Token = value; }
        }


        public static string ENCODING_AES_KEY
        {
            get { return DingConfig._ENCODING_AES_KEY; }
            set { DingConfig._ENCODING_AES_KEY = value; }
        }




        static DingConfig()
        {
            _ECorpId = ConfigurationKeys.ECorpId;
            _ECorpSecret = ConfigurationKeys.ECorpSecret;
            _EAgentID = ConfigurationKeys.EAgentID;
            _webUrl = ConfigurationKeys.WebUrl;

            _SUITE_KEY = ConfigurationKeys.SUITE_KEY;
            _SUITE_KEY_SECRET = ConfigurationKeys.SUITE_KEY_SECRET;
            _Token = ConfigurationKeys.Token;
            _ENCODING_AES_KEY = ConfigurationKeys.ENCODING_AES_KEY;

            //_ECorpId = ConfigurationManager.AppSettings[ConfigurationKeys.ECorpId];
            //_ECorpSecret = ConfigurationManager.AppSettings[ConfigurationKeys.ECorpSecret];
            //_EAgentID = ConfigurationManager.AppSettings[ConfigurationKeys.EAgentID];
            //_webUrl = ConfigurationManager.AppSettings[ConfigurationKeys.WebUrl];

            //_SUITE_KEY = ConfigurationManager.AppSettings[ConfigurationKeys.SUITE_KEY];
            //_SUITE_KEY_SECRET = ConfigurationManager.AppSettings[ConfigurationKeys.SUITE_KEY_SECRET];
            //_Token = ConfigurationManager.AppSettings[ConfigurationKeys.Token];
            //_ENCODING_AES_KEY = ConfigurationManager.AppSettings[ConfigurationKeys.ENCODING_AES_KEY];
        }

        public static void AnotherKeys()
        {
            _ECorpId = ConfigurationAnotherKeys.ECorpId;
            _ECorpSecret = ConfigurationAnotherKeys.ECorpSecret;
            _EAgentID = ConfigurationAnotherKeys.EAgentID;
            _webUrl = ConfigurationAnotherKeys.WebUrl;

            _SUITE_KEY = ConfigurationAnotherKeys.SUITE_KEY;
            _SUITE_KEY_SECRET = ConfigurationAnotherKeys.SUITE_KEY_SECRET;
            _Token = ConfigurationAnotherKeys.Token;
            _ENCODING_AES_KEY = ConfigurationAnotherKeys.ENCODING_AES_KEY;

            //_ECorpId = ConfigurationManager.AppSettings[ConfigurationKeys.ECorpId];
            //_ECorpSecret = ConfigurationManager.AppSettings[ConfigurationKeys.ECorpSecret];
            //_EAgentID = ConfigurationManager.AppSettings[ConfigurationKeys.EAgentID];
            //_webUrl = ConfigurationManager.AppSettings[ConfigurationKeys.WebUrl];

            //_SUITE_KEY = ConfigurationManager.AppSettings[ConfigurationKeys.SUITE_KEY];
            //_SUITE_KEY_SECRET = ConfigurationManager.AppSettings[ConfigurationKeys.SUITE_KEY_SECRET];
            //_Token = ConfigurationManager.AppSettings[ConfigurationKeys.Token];
            //_ENCODING_AES_KEY = ConfigurationManager.AppSettings[ConfigurationKeys.ENCODING_AES_KEY];
        }

        public static void GetKeys()
        {
            _ECorpId = ConfigurationKeys.ECorpId;
            _ECorpSecret = ConfigurationKeys.ECorpSecret;
            _EAgentID = ConfigurationKeys.EAgentID;
            _webUrl = ConfigurationKeys.WebUrl;

            _SUITE_KEY = ConfigurationKeys.SUITE_KEY;
            _SUITE_KEY_SECRET = ConfigurationKeys.SUITE_KEY_SECRET;
            _Token = ConfigurationKeys.Token;
            _ENCODING_AES_KEY = ConfigurationKeys.ENCODING_AES_KEY;

            //_ECorpId = ConfigurationManager.AppSettings[ConfigurationKeys.ECorpId];
            //_ECorpSecret = ConfigurationManager.AppSettings[ConfigurationKeys.ECorpSecret];
            //_EAgentID = ConfigurationManager.AppSettings[ConfigurationKeys.EAgentID];
            //_webUrl = ConfigurationManager.AppSettings[ConfigurationKeys.WebUrl];

            //_SUITE_KEY = ConfigurationManager.AppSettings[ConfigurationKeys.SUITE_KEY];
            //_SUITE_KEY_SECRET = ConfigurationManager.AppSettings[ConfigurationKeys.SUITE_KEY_SECRET];
            //_Token = ConfigurationManager.AppSettings[ConfigurationKeys.Token];
            //_ENCODING_AES_KEY = ConfigurationManager.AppSettings[ConfigurationKeys.ENCODING_AES_KEY];
        }


        private static class ConfigurationKeys
        {
            public const string ECorpId = "ding1f18b35b5e0f824c35c2f4657eb6378f";
            public const string ECorpSecret = "-vKvh_k4uq0L0NYqgkb-T7tAABoVeKVlkg4KsSbKySWyPJYnjPxlaZfnqBGvWiOI";
            public const string EAgentID = "E.AgentID";
            public const string WebUrl = "webUrl";


            public const string SUITE_KEY = "SUITE_KEY";
            public const string SUITE_KEY_SECRET = "SUITE_KEY_SECRET";
            public const string Token = "Token";
            public const string ENCODING_AES_KEY = "ENCODING_AES_KEY";

        }

        /// <summary>
        /// 其它公司key
        /// </summary>
        private static class ConfigurationAnotherKeys
        {
            public const string ECorpId = "dingee5sc5id1ruqviaa";
            public const string ECorpSecret = "ziEZ8EcCTMxigXolGmMJ7aO4PyMjszHoaTWETqfj88d9mlbcPobMnYeWlqviI3ag";
            public const string EAgentID = "E.AgentID";
            public const string WebUrl = "webUrl";


            public const string SUITE_KEY = "SUITE_KEY";
            public const string SUITE_KEY_SECRET = "SUITE_KEY_SECRET";
            public const string Token = "Token";
            public const string ENCODING_AES_KEY = "ENCODING_AES_KEY";
        }
    }
}
