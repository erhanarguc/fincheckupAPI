namespace fincheckup.Models.Qnb.soap
{
    public static class QnbSoapResponse
    {
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
        public partial class Envelope
        {

            private EnvelopeBody bodyField;

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
        public partial class EnvelopeBody
        {

            private userValidationByQnbUserIdResponse userValidationByQnbUserIdResponseField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://services.teminat.finansman.uut.cs.com.tr/")]
            public userValidationByQnbUserIdResponse userValidationByQnbUserIdResponse
            {
                get
                {
                    return this.userValidationByQnbUserIdResponseField;
                }
                set
                {
                    this.userValidationByQnbUserIdResponseField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://services.teminat.finansman.uut.cs.com.tr/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://services.teminat.finansman.uut.cs.com.tr/", IsNullable = false)]
        public partial class userValidationByQnbUserIdResponse
        {

            private @return returnField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public @return @return
            {
                get
                {
                    return this.returnField;
                }
                set
                {
                    this.returnField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class @return
        {

            private string responseCodeField;

            private string responseMessageField;

            private bool successField;

            /// <remarks/>
            public string responseCode
            {
                get
                {
                    return this.responseCodeField;
                }
                set
                {
                    this.responseCodeField = value;
                }
            }

            /// <remarks/>
            public string responseMessage
            {
                get
                {
                    return this.responseMessageField;
                }
                set
                {
                    this.responseMessageField = value;
                }
            }

            /// <remarks/>
            public bool success
            {
                get
                {
                    return this.successField;
                }
                set
                {
                    this.successField = value;
                }
            }
        }


    }


    public static class QnbSoapResponse1
    {


        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
        public partial class Envelope
        {

            private EnvelopeBody bodyField;

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
        public partial class EnvelopeBody
        {

            private userValidationByUserIdPasswordResponse userValidationByUserIdPasswordResponseField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://services.teminat.finansman.uut.cs.com.tr/")]
            public userValidationByUserIdPasswordResponse userValidationByUserIdPasswordResponse
            {
                get
                {
                    return this.userValidationByUserIdPasswordResponseField;
                }
                set
                {
                    this.userValidationByUserIdPasswordResponseField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://services.teminat.finansman.uut.cs.com.tr/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://services.teminat.finansman.uut.cs.com.tr/", IsNullable = false)]
        public partial class userValidationByUserIdPasswordResponse
        {

            private @return returnField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public @return @return
            {
                get
                {
                    return this.returnField;
                }
                set
                {
                    this.returnField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class @return
        {

            private string responseCodeField;

            private string responseMessageField;

            private bool successField;

            /// <remarks/>
            public string responseCode
            {
                get
                {
                    return this.responseCodeField;
                }
                set
                {
                    this.responseCodeField = value;
                }
            }

            /// <remarks/>
            public string responseMessage
            {
                get
                {
                    return this.responseMessageField;
                }
                set
                {
                    this.responseMessageField = value;
                }
            }

            /// <remarks/>
            public bool success
            {
                get
                {
                    return this.successField;
                }
                set
                {
                    this.successField = value;
                }
            }
        }



    }

    public static class QnbSoapResponse3
    {


        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
        public partial class Envelope
        {

            private EnvelopeBody bodyField;

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
        public partial class EnvelopeBody
        {

            private defterIzinSilResponse defterIzinSilResponseField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://services.teminat.finansman.uut.cs.com.tr/")]
            public defterIzinSilResponse defterIzinSilResponse
            {
                get
                {
                    return this.defterIzinSilResponseField;
                }
                set
                {
                    this.defterIzinSilResponseField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://services.teminat.finansman.uut.cs.com.tr/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://services.teminat.finansman.uut.cs.com.tr/", IsNullable = false)]
        public partial class defterIzinSilResponse
        {

            private @return returnField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public @return @return
            {
                get
                {
                    return this.returnField;
                }
                set
                {
                    this.returnField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class @return
        {

            private string responseCodeField;

            private string responseMessageField;

            private bool successField;

            /// <remarks/>
            public string responseCode
            {
                get
                {
                    return this.responseCodeField;
                }
                set
                {
                    this.responseCodeField = value;
                }
            }

            /// <remarks/>
            public string responseMessage
            {
                get
                {
                    return this.responseMessageField;
                }
                set
                {
                    this.responseMessageField = value;
                }
            }

            /// <remarks/>
            public bool success
            {
                get
                {
                    return this.successField;
                }
                set
                {
                    this.successField = value;
                }
            }
        }


    }

    public static class QnbSoapResponse5
    {


        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
        public partial class Envelope
        {

            private EnvelopeBody bodyField;

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
        public partial class EnvelopeBody
        {

            private defterIzinKaydetResponse defterIzinKaydetResponseField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://services.teminat.finansman.uut.cs.com.tr/")]
            public defterIzinKaydetResponse defterIzinKaydetResponse
            {
                get
                {
                    return this.defterIzinKaydetResponseField;
                }
                set
                {
                    this.defterIzinKaydetResponseField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://services.teminat.finansman.uut.cs.com.tr/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://services.teminat.finansman.uut.cs.com.tr/", IsNullable = false)]
        public partial class defterIzinKaydetResponse
        {

            private @return returnField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public @return @return
            {
                get
                {
                    return this.returnField;
                }
                set
                {
                    this.returnField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class @return
        {

            private string responseCodeField;

            private string responseMessageField;

            private bool successField;

            /// <remarks/>
            public string responseCode
            {
                get
                {
                    return this.responseCodeField;
                }
                set
                {
                    this.responseCodeField = value;
                }
            }

            /// <remarks/>
            public string responseMessage
            {
                get
                {
                    return this.responseMessageField;
                }
                set
                {
                    this.responseMessageField = value;
                }
            }

            /// <remarks/>
            public bool success
            {
                get
                {
                    return this.successField;
                }
                set
                {
                    this.successField = value;
                }
            }
        }


    }
}
