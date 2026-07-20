namespace fincheckup.Models.Qnb
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class Envelope
    {

        private EnvelopeHeader headerField;

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public EnvelopeBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeHeader
    {

        private Security securityField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
            "")]
        public Security Security
        {
            get
            {
                return this.securityField;
            }
            set
            {
                this.securityField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "", IsNullable = false)]
    public partial class Security
    {

        private SecurityUsernameToken usernameTokenField;

        private byte mustUnderstandField;

        /// <remarks/>
        public SecurityUsernameToken UsernameToken
        {
            get
            {
                return this.usernameTokenField;
            }
            set
            {
                this.usernameTokenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "soap")]
        public byte mustUnderstand
        {
            get
            {
                return this.mustUnderstandField;
            }
            set
            {
                this.mustUnderstandField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "")]
    public partial class SecurityUsernameToken
    {

        private string usernameField;

        private string passwordField;

        private string[] textField;

        /// <remarks/>
        public string Username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private kullaniciDogrulamaByQnbUserId kullaniciDogrulamaByQnbUserIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://finCheckUpEntegrasyonuService.service.connector.uut.cs.com.tr/")]
        public kullaniciDogrulamaByQnbUserId kullaniciDogrulamaByQnbUserId
        {
            get
            {
                return this.kullaniciDogrulamaByQnbUserIdField;
            }
            set
            {
                this.kullaniciDogrulamaByQnbUserIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://finCheckUpEntegrasyonuService.service.connector.uut.cs.com.tr/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://finCheckUpEntegrasyonuService.service.connector.uut.cs.com.tr/", IsNullable = false)]
    public partial class kullaniciDogrulamaByQnbUserId
    {

        private string vknTcknField;

        private string qnbUserIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string vknTckn
        {
            get
            {
                return this.vknTcknField;
            }
            set
            {
                this.vknTcknField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string qnbUserId
        {
            get
            {
                return this.qnbUserIdField;
            }
            set
            {
                this.qnbUserIdField = value;
            }
        }
    }




}
