namespace fincheckup.Models.NKolayUyumsoft
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.edefter.gov.tr")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.edefter.gov.tr", IsNullable = false)]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class defter
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {

        private xbrl xbrlField;

        private Signature signatureField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/2003/instance")]
        public xbrl xbrl
        {
            get
            {
                return this.xbrlField;
            }
            set
            {
                this.xbrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/2003/instance", IsNullable = false)]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class xbrl
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {

        private schemaRef schemaRefField;

        private xbrlContext contextField;

        private xbrlUnit[] unitField;

        private accountingEntries accountingEntriesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/2003/linkbase")]
        public schemaRef schemaRef
        {
            get
            {
                return this.schemaRefField;
            }
            set
            {
                this.schemaRefField = value;
            }
        }

        /// <remarks/>
        public xbrlContext context
        {
            get
            {
                return this.contextField;
            }
            set
            {
                this.contextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("unit")]
        public xbrlUnit[] unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
        public accountingEntries accountingEntries
        {
            get
            {
                return this.accountingEntriesField;
            }
            set
            {
                this.accountingEntriesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/linkbase")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/2003/linkbase", IsNullable = false)]
    public partial class schemaRef
    {

        private string hrefField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlContext
    {

        private xbrlContextEntity entityField;

        private xbrlContextPeriod periodField;

        private string idField;

        /// <remarks/>
        public xbrlContextEntity entity
        {
            get
            {
                return this.entityField;
            }
            set
            {
                this.entityField = value;
            }
        }

        /// <remarks/>
        public xbrlContextPeriod period
        {
            get
            {
                return this.periodField;
            }
            set
            {
                this.periodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlContextEntity
    {

        private xbrlContextEntityIdentifier identifierField;

        /// <remarks/>
        public xbrlContextEntityIdentifier identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlContextEntityIdentifier
    {

        private string schemeField;

        private ulong valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string scheme
        {
            get
            {
                return this.schemeField;
            }
            set
            {
                this.schemeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ulong Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlContextPeriod
    {

        private System.DateTime instantField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime instant
        {
            get
            {
                return this.instantField;
            }
            set
            {
                this.instantField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlUnit
    {

        private string measureField;

        private string idField;

        /// <remarks/>
        public string measure
        {
            get
            {
                return this.measureField;
            }
            set
            {
                this.measureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25", IsNullable = false)]
    public partial class accountingEntries
    {

        private accountingEntriesDocumentInfo documentInfoField;

        private accountingEntriesEntityInformation entityInformationField;

        private accountingEntriesEntryHeader[] entryHeaderField;

        /// <remarks/>
        public accountingEntriesDocumentInfo documentInfo
        {
            get
            {
                return this.documentInfoField;
            }
            set
            {
                this.documentInfoField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntityInformation entityInformation
        {
            get
            {
                return this.entityInformationField;
            }
            set
            {
                this.entityInformationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("entryHeader")]
        public accountingEntriesEntryHeader[] entryHeader
        {
            get
            {
                return this.entryHeaderField;
            }
            set
            {
                this.entryHeaderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfo
    {

        private accountingEntriesDocumentInfoEntriesType entriesTypeField;

        private accountingEntriesDocumentInfoUniqueID uniqueIDField;

        private accountingEntriesDocumentInfoLanguage languageField;

        private accountingEntriesDocumentInfoCreationDate creationDateField;

        private creator creatorField;

        private accountingEntriesDocumentInfoEntriesComment entriesCommentField;

        private accountingEntriesDocumentInfoPeriodCoveredStart periodCoveredStartField;

        private accountingEntriesDocumentInfoPeriodCoveredEnd periodCoveredEndField;

        private sourceApplication sourceApplicationField;

        /// <remarks/>
        public accountingEntriesDocumentInfoEntriesType entriesType
        {
            get
            {
                return this.entriesTypeField;
            }
            set
            {
                this.entriesTypeField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoUniqueID uniqueID
        {
            get
            {
                return this.uniqueIDField;
            }
            set
            {
                this.uniqueIDField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoLanguage language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoCreationDate creationDate
        {
            get
            {
                return this.creationDateField;
            }
            set
            {
                this.creationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public creator creator
        {
            get
            {
                return this.creatorField;
            }
            set
            {
                this.creatorField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoEntriesComment entriesComment
        {
            get
            {
                return this.entriesCommentField;
            }
            set
            {
                this.entriesCommentField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoPeriodCoveredStart periodCoveredStart
        {
            get
            {
                return this.periodCoveredStartField;
            }
            set
            {
                this.periodCoveredStartField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoPeriodCoveredEnd periodCoveredEnd
        {
            get
            {
                return this.periodCoveredEndField;
            }
            set
            {
                this.periodCoveredEndField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public sourceApplication sourceApplication
        {
            get
            {
                return this.sourceApplicationField;
            }
            set
            {
                this.sourceApplicationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoEntriesType
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoUniqueID
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoLanguage
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoCreationDate
    {

        private string contextRefField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "date")]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class creator
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoEntriesComment
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoPeriodCoveredStart
    {

        private string contextRefField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "date")]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoPeriodCoveredEnd
    {

        private string contextRefField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "date")]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class sourceApplication
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntityInformation
    {

        private entityPhoneNumber entityPhoneNumberField;

        private entityFaxNumberStructure entityFaxNumberStructureField;

        private entityEmailAddressStructure entityEmailAddressStructureField;

        private organizationIdentifiers[] organizationIdentifiersField;

        private organizationAddress organizationAddressField;

        private entityWebSite entityWebSiteField;

        private businessDescription businessDescriptionField;

        private fiscalYearStart fiscalYearStartField;

        private fiscalYearEnd fiscalYearEndField;

        private accountantInformation accountantInformationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public entityPhoneNumber entityPhoneNumber
        {
            get
            {
                return this.entityPhoneNumberField;
            }
            set
            {
                this.entityPhoneNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public entityFaxNumberStructure entityFaxNumberStructure
        {
            get
            {
                return this.entityFaxNumberStructureField;
            }
            set
            {
                this.entityFaxNumberStructureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public entityEmailAddressStructure entityEmailAddressStructure
        {
            get
            {
                return this.entityEmailAddressStructureField;
            }
            set
            {
                this.entityEmailAddressStructureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("organizationIdentifiers", Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public organizationIdentifiers[] organizationIdentifiers
        {
            get
            {
                return this.organizationIdentifiersField;
            }
            set
            {
                this.organizationIdentifiersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public organizationAddress organizationAddress
        {
            get
            {
                return this.organizationAddressField;
            }
            set
            {
                this.organizationAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public entityWebSite entityWebSite
        {
            get
            {
                return this.entityWebSiteField;
            }
            set
            {
                this.entityWebSiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public businessDescription businessDescription
        {
            get
            {
                return this.businessDescriptionField;
            }
            set
            {
                this.businessDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public fiscalYearStart fiscalYearStart
        {
            get
            {
                return this.fiscalYearStartField;
            }
            set
            {
                this.fiscalYearStartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public fiscalYearEnd fiscalYearEnd
        {
            get
            {
                return this.fiscalYearEndField;
            }
            set
            {
                this.fiscalYearEndField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public accountantInformation accountantInformation
        {
            get
            {
                return this.accountantInformationField;
            }
            set
            {
                this.accountantInformationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class entityPhoneNumber
    {

        private entityPhoneNumberPhoneNumberDescription phoneNumberDescriptionField;

        private entityPhoneNumberPhoneNumber phoneNumberField;

        /// <remarks/>
        public entityPhoneNumberPhoneNumberDescription phoneNumberDescription
        {
            get
            {
                return this.phoneNumberDescriptionField;
            }
            set
            {
                this.phoneNumberDescriptionField = value;
            }
        }

        /// <remarks/>
        public entityPhoneNumberPhoneNumber phoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityPhoneNumberPhoneNumberDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityPhoneNumberPhoneNumber
    {

        private string contextRefField;

        private uint valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public uint Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class entityFaxNumberStructure
    {

        private entityFaxNumberStructureEntityFaxNumber entityFaxNumberField;

        /// <remarks/>
        public entityFaxNumberStructureEntityFaxNumber entityFaxNumber
        {
            get
            {
                return this.entityFaxNumberField;
            }
            set
            {
                this.entityFaxNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityFaxNumberStructureEntityFaxNumber
    {

        private string contextRefField;

        private uint valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public uint Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class entityEmailAddressStructure
    {

        private entityEmailAddressStructureEntityEmailAddress entityEmailAddressField;

        /// <remarks/>
        public entityEmailAddressStructureEntityEmailAddress entityEmailAddress
        {
            get
            {
                return this.entityEmailAddressField;
            }
            set
            {
                this.entityEmailAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityEmailAddressStructureEntityEmailAddress
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class organizationIdentifiers
    {

        private organizationIdentifiersOrganizationIdentifier organizationIdentifierField;

        private organizationIdentifiersOrganizationDescription organizationDescriptionField;

        /// <remarks/>
        public organizationIdentifiersOrganizationIdentifier organizationIdentifier
        {
            get
            {
                return this.organizationIdentifierField;
            }
            set
            {
                this.organizationIdentifierField = value;
            }
        }

        /// <remarks/>
        public organizationIdentifiersOrganizationDescription organizationDescription
        {
            get
            {
                return this.organizationDescriptionField;
            }
            set
            {
                this.organizationDescriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationIdentifiersOrganizationIdentifier
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationIdentifiersOrganizationDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class organizationAddress
    {

        private organizationAddressOrganizationBuildingNumber organizationBuildingNumberField;

        private organizationAddressOrganizationAddressStreet organizationAddressStreetField;

        private organizationAddressOrganizationAddressStreet2 organizationAddressStreet2Field;

        private organizationAddressOrganizationAddressCity organizationAddressCityField;

        private organizationAddressOrganizationAddressZipOrPostalCode organizationAddressZipOrPostalCodeField;

        private organizationAddressOrganizationAddressCountry organizationAddressCountryField;

        /// <remarks/>
        public organizationAddressOrganizationBuildingNumber organizationBuildingNumber
        {
            get
            {
                return this.organizationBuildingNumberField;
            }
            set
            {
                this.organizationBuildingNumberField = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressStreet organizationAddressStreet
        {
            get
            {
                return this.organizationAddressStreetField;
            }
            set
            {
                this.organizationAddressStreetField = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressStreet2 organizationAddressStreet2
        {
            get
            {
                return this.organizationAddressStreet2Field;
            }
            set
            {
                this.organizationAddressStreet2Field = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressCity organizationAddressCity
        {
            get
            {
                return this.organizationAddressCityField;
            }
            set
            {
                this.organizationAddressCityField = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressZipOrPostalCode organizationAddressZipOrPostalCode
        {
            get
            {
                return this.organizationAddressZipOrPostalCodeField;
            }
            set
            {
                this.organizationAddressZipOrPostalCodeField = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressCountry organizationAddressCountry
        {
            get
            {
                return this.organizationAddressCountryField;
            }
            set
            {
                this.organizationAddressCountryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationBuildingNumber
    {

        private string contextRefField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressStreet
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressStreet2
    {

        private string contextRefField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressCity
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressZipOrPostalCode
    {

        private string contextRefField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressCountry
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class entityWebSite
    {

        private entityWebSiteWebSiteURL webSiteURLField;

        /// <remarks/>
        public entityWebSiteWebSiteURL webSiteURL
        {
            get
            {
                return this.webSiteURLField;
            }
            set
            {
                this.webSiteURLField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityWebSiteWebSiteURL
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class businessDescription
    {

        private string contextRefField;

        private uint valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public uint Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class fiscalYearStart
    {

        private string contextRefField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "date")]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class fiscalYearEnd
    {

        private string contextRefField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "date")]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class accountantInformation
    {

        private accountantInformationAccountantName accountantNameField;

        private accountantInformationAccountantAddress accountantAddressField;

        private accountantInformationAccountantEngagementTypeDescription accountantEngagementTypeDescriptionField;

        private accountantInformationAccountantContactInformation accountantContactInformationField;

        /// <remarks/>
        public accountantInformationAccountantName accountantName
        {
            get
            {
                return this.accountantNameField;
            }
            set
            {
                this.accountantNameField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddress accountantAddress
        {
            get
            {
                return this.accountantAddressField;
            }
            set
            {
                this.accountantAddressField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantEngagementTypeDescription accountantEngagementTypeDescription
        {
            get
            {
                return this.accountantEngagementTypeDescriptionField;
            }
            set
            {
                this.accountantEngagementTypeDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantContactInformation accountantContactInformation
        {
            get
            {
                return this.accountantContactInformationField;
            }
            set
            {
                this.accountantContactInformationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantName
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddress
    {

        private accountantInformationAccountantAddressAccountantBuildingNumber accountantBuildingNumberField;

        private accountantInformationAccountantAddressAccountantStreet accountantStreetField;

        private accountantInformationAccountantAddressAccountantAddressStreet2 accountantAddressStreet2Field;

        private accountantInformationAccountantAddressAccountantCity accountantCityField;

        private accountantInformationAccountantAddressAccountantCountry accountantCountryField;

        private accountantInformationAccountantAddressAccountantZipOrPostalCode accountantZipOrPostalCodeField;

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantBuildingNumber accountantBuildingNumber
        {
            get
            {
                return this.accountantBuildingNumberField;
            }
            set
            {
                this.accountantBuildingNumberField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantStreet accountantStreet
        {
            get
            {
                return this.accountantStreetField;
            }
            set
            {
                this.accountantStreetField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantAddressStreet2 accountantAddressStreet2
        {
            get
            {
                return this.accountantAddressStreet2Field;
            }
            set
            {
                this.accountantAddressStreet2Field = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantCity accountantCity
        {
            get
            {
                return this.accountantCityField;
            }
            set
            {
                this.accountantCityField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantCountry accountantCountry
        {
            get
            {
                return this.accountantCountryField;
            }
            set
            {
                this.accountantCountryField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantZipOrPostalCode accountantZipOrPostalCode
        {
            get
            {
                return this.accountantZipOrPostalCodeField;
            }
            set
            {
                this.accountantZipOrPostalCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantBuildingNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantStreet
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantAddressStreet2
    {

        private string contextRefField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantCity
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantCountry
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantZipOrPostalCode
    {

        private string contextRefField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantEngagementTypeDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformation
    {

        private accountantInformationAccountantContactInformationAccountantContactPhone accountantContactPhoneField;

        private accountantInformationAccountantContactInformationAccountantContactFax accountantContactFaxField;

        private accountantInformationAccountantContactInformationAccountantContactEmail accountantContactEmailField;

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactPhone accountantContactPhone
        {
            get
            {
                return this.accountantContactPhoneField;
            }
            set
            {
                this.accountantContactPhoneField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactFax accountantContactFax
        {
            get
            {
                return this.accountantContactFaxField;
            }
            set
            {
                this.accountantContactFaxField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactEmail accountantContactEmail
        {
            get
            {
                return this.accountantContactEmailField;
            }
            set
            {
                this.accountantContactEmailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactPhone
    {

        private accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumberDescription accountantContactPhoneNumberDescriptionField;

        private accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumber accountantContactPhoneNumberField;

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumberDescription accountantContactPhoneNumberDescription
        {
            get
            {
                return this.accountantContactPhoneNumberDescriptionField;
            }
            set
            {
                this.accountantContactPhoneNumberDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumber accountantContactPhoneNumber
        {
            get
            {
                return this.accountantContactPhoneNumberField;
            }
            set
            {
                this.accountantContactPhoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumberDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumber
    {

        private string contextRefField;

        private uint valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public uint Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactFax
    {

        private accountantInformationAccountantContactInformationAccountantContactFaxAccountantContactFaxNumber accountantContactFaxNumberField;

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactFaxAccountantContactFaxNumber accountantContactFaxNumber
        {
            get
            {
                return this.accountantContactFaxNumberField;
            }
            set
            {
                this.accountantContactFaxNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactFaxAccountantContactFaxNumber
    {

        private string contextRefField;

        private uint valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public uint Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactEmail
    {

        private accountantInformationAccountantContactInformationAccountantContactEmailAccountantContactEmailAddress accountantContactEmailAddressField;

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactEmailAccountantContactEmailAddress accountantContactEmailAddress
        {
            get
            {
                return this.accountantContactEmailAddressField;
            }
            set
            {
                this.accountantContactEmailAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactEmailAccountantContactEmailAddress
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeader
    {

        private accountingEntriesEntryHeaderEnteredBy enteredByField;

        private accountingEntriesEntryHeaderEnteredDate enteredDateField;

        private accountingEntriesEntryHeaderEntryNumber entryNumberField;

        private accountingEntriesEntryHeaderEntryComment entryCommentField;

        private totalDebit totalDebitField;

        private totalCredit totalCreditField;

        private accountingEntriesEntryHeaderEntryNumberCounter entryNumberCounterField;

        private accountingEntriesEntryHeaderEntryDetail[] entryDetailField;

        /// <remarks/>
        public accountingEntriesEntryHeaderEnteredBy enteredBy
        {
            get
            {
                return this.enteredByField;
            }
            set
            {
                this.enteredByField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEnteredDate enteredDate
        {
            get
            {
                return this.enteredDateField;
            }
            set
            {
                this.enteredDateField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryNumber entryNumber
        {
            get
            {
                return this.entryNumberField;
            }
            set
            {
                this.entryNumberField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryComment entryComment
        {
            get
            {
                return this.entryCommentField;
            }
            set
            {
                this.entryCommentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public totalDebit totalDebit
        {
            get
            {
                return this.totalDebitField;
            }
            set
            {
                this.totalDebitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public totalCredit totalCredit
        {
            get
            {
                return this.totalCreditField;
            }
            set
            {
                this.totalCreditField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryNumberCounter entryNumberCounter
        {
            get
            {
                return this.entryNumberCounterField;
            }
            set
            {
                this.entryNumberCounterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("entryDetail")]
        public accountingEntriesEntryHeaderEntryDetail[] entryDetail
        {
            get
            {
                return this.entryDetailField;
            }
            set
            {
                this.entryDetailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEnteredBy
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEnteredDate
    {

        private string contextRefField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "date")]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryNumber
    {

        private string contextRefField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryComment
    {

        private string contextRefField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class totalDebit
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float decimals
        {
            get
            {
                return this.decimalsField;
            }
            set
            {
                this.decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitRef
        {
            get
            {
                return this.unitRefField;
            }
            set
            {
                this.unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class totalCredit
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float decimals
        {
            get
            {
                return this.decimalsField;
            }
            set
            {
                this.decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitRef
        {
            get
            {
                return this.unitRefField;
            }
            set
            {
                this.unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryNumberCounter
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float decimals
        {
            get
            {
                return this.decimalsField;
            }
            set
            {
                this.decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitRef
        {
            get
            {
                return this.unitRefField;
            }
            set
            {
                this.unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetail
    {

        private accountingEntriesEntryHeaderEntryDetailLineNumber lineNumberField;

        private accountingEntriesEntryHeaderEntryDetailLineNumberCounter lineNumberCounterField;

        private accountingEntriesEntryHeaderEntryDetailAccount accountField;

        private accountingEntriesEntryHeaderEntryDetailAmount amountField;

        private accountingEntriesEntryHeaderEntryDetailDebitCreditCode debitCreditCodeField;

        private accountingEntriesEntryHeaderEntryDetailPostingDate postingDateField;

        private accountingEntriesEntryHeaderEntryDetailDocumentType documentTypeField;

        private accountingEntriesEntryHeaderEntryDetailDocumentTypeDescription documentTypeDescriptionField;

        private accountingEntriesEntryHeaderEntryDetailDocumentNumber documentNumberField;

        private accountingEntriesEntryHeaderEntryDetailDocumentReference documentReferenceField;

        private accountingEntriesEntryHeaderEntryDetailDocumentDate documentDateField;

        private paymentMethod paymentMethodField;

        private accountingEntriesEntryHeaderEntryDetailDetailComment detailCommentField;

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailLineNumber lineNumber
        {
            get
            {
                return this.lineNumberField;
            }
            set
            {
                this.lineNumberField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailLineNumberCounter lineNumberCounter
        {
            get
            {
                return this.lineNumberCounterField;
            }
            set
            {
                this.lineNumberCounterField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccount account
        {
            get
            {
                return this.accountField;
            }
            set
            {
                this.accountField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAmount amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDebitCreditCode debitCreditCode
        {
            get
            {
                return this.debitCreditCodeField;
            }
            set
            {
                this.debitCreditCodeField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailPostingDate postingDate
        {
            get
            {
                return this.postingDateField;
            }
            set
            {
                this.postingDateField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentType documentType
        {
            get
            {
                return this.documentTypeField;
            }
            set
            {
                this.documentTypeField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentTypeDescription documentTypeDescription
        {
            get
            {
                return this.documentTypeDescriptionField;
            }
            set
            {
                this.documentTypeDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentNumber documentNumber
        {
            get
            {
                return this.documentNumberField;
            }
            set
            {
                this.documentNumberField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentReference documentReference
        {
            get
            {
                return this.documentReferenceField;
            }
            set
            {
                this.documentReferenceField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentDate documentDate
        {
            get
            {
                return this.documentDateField;
            }
            set
            {
                this.documentDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public paymentMethod paymentMethod
        {
            get
            {
                return this.paymentMethodField;
            }
            set
            {
                this.paymentMethodField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDetailComment detailComment
        {
            get
            {
                return this.detailCommentField;
            }
            set
            {
                this.detailCommentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailLineNumber
    {

        private string contextRefField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailLineNumberCounter
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float decimals
        {
            get
            {
                return this.decimalsField;
            }
            set
            {
                this.decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitRef
        {
            get
            {
                return this.unitRefField;
            }
            set
            {
                this.unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccount
    {

        private accountingEntriesEntryHeaderEntryDetailAccountAccountMainID accountMainIDField;

        private accountingEntriesEntryHeaderEntryDetailAccountAccountMainDescription accountMainDescriptionField;

        private accountingEntriesEntryHeaderEntryDetailAccountAccountSub accountSubField;

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountMainID accountMainID
        {
            get
            {
                return this.accountMainIDField;
            }
            set
            {
                this.accountMainIDField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountMainDescription accountMainDescription
        {
            get
            {
                return this.accountMainDescriptionField;
            }
            set
            {
                this.accountMainDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountSub accountSub
        {
            get
            {
                return this.accountSubField;
            }
            set
            {
                this.accountSubField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountMainID
    {

        private string contextRefField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountMainDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountSub
    {

        private accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubDescription accountSubDescriptionField;

        private accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubID accountSubIDField;

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubDescription accountSubDescription
        {
            get
            {
                return this.accountSubDescriptionField;
            }
            set
            {
                this.accountSubDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubID accountSubID
        {
            get
            {
                return this.accountSubIDField;
            }
            set
            {
                this.accountSubIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubID
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAmount
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float decimals
        {
            get
            {
                return this.decimalsField;
            }
            set
            {
                this.decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitRef
        {
            get
            {
                return this.unitRefField;
            }
            set
            {
                this.unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDebitCreditCode
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailPostingDate
    {

        private string contextRefField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "date")]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentType
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentTypeDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentReference
    {

        private string contextRefField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentDate
    {

        private string contextRefField;

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "date")]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class paymentMethod
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDetailComment
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contextRef
        {
            get
            {
                return this.contextRefField;
            }
            set
            {
                this.contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class Signature
    {

        private SignatureSignedInfo signedInfoField;

        private SignatureSignatureValue signatureValueField;

        private SignatureKeyInfo keyInfoField;

        private SignatureObject objectField;

        private string idField;

        /// <remarks/>
        public SignatureSignedInfo SignedInfo
        {
            get
            {
                return this.signedInfoField;
            }
            set
            {
                this.signedInfoField = value;
            }
        }

        /// <remarks/>
        public SignatureSignatureValue SignatureValue
        {
            get
            {
                return this.signatureValueField;
            }
            set
            {
                this.signatureValueField = value;
            }
        }

        /// <remarks/>
        public SignatureKeyInfo KeyInfo
        {
            get
            {
                return this.keyInfoField;
            }
            set
            {
                this.keyInfoField = value;
            }
        }

        /// <remarks/>
        public SignatureObject Object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfo
    {

        private SignatureSignedInfoCanonicalizationMethod canonicalizationMethodField;

        private SignatureSignedInfoSignatureMethod signatureMethodField;

        private SignatureSignedInfoReference[] referenceField;

        /// <remarks/>
        public SignatureSignedInfoCanonicalizationMethod CanonicalizationMethod
        {
            get
            {
                return this.canonicalizationMethodField;
            }
            set
            {
                this.canonicalizationMethodField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoSignatureMethod SignatureMethod
        {
            get
            {
                return this.signatureMethodField;
            }
            set
            {
                this.signatureMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Reference")]
        public SignatureSignedInfoReference[] Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoCanonicalizationMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoSignatureMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReference
    {

        private SignatureSignedInfoReferenceTransforms transformsField;

        private SignatureSignedInfoReferenceDigestMethod digestMethodField;

        private string digestValueField;

        private string idField;

        private string uRIField;

        private string typeField;

        /// <remarks/>
        public SignatureSignedInfoReferenceTransforms Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoReferenceDigestMethod DigestMethod
        {
            get
            {
                return this.digestMethodField;
            }
            set
            {
                this.digestMethodField = value;
            }
        }

        /// <remarks/>
        public string DigestValue
        {
            get
            {
                return this.digestValueField;
            }
            set
            {
                this.digestValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceTransforms
    {

        private SignatureSignedInfoReferenceTransformsTransform transformField;

        /// <remarks/>
        public SignatureSignedInfoReferenceTransformsTransform Transform
        {
            get
            {
                return this.transformField;
            }
            set
            {
                this.transformField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceTransformsTransform
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceDigestMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignatureValue
    {

        private string idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfo
    {

        private SignatureKeyInfoX509Data x509DataField;

        private SignatureKeyInfoKeyValue keyValueField;

        /// <remarks/>
        public SignatureKeyInfoX509Data X509Data
        {
            get
            {
                return this.x509DataField;
            }
            set
            {
                this.x509DataField = value;
            }
        }

        /// <remarks/>
        public SignatureKeyInfoKeyValue KeyValue
        {
            get
            {
                return this.keyValueField;
            }
            set
            {
                this.keyValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfoX509Data
    {

        private string x509CertificateField;

        private string x509SubjectNameField;

        /// <remarks/>
        public string X509Certificate
        {
            get
            {
                return this.x509CertificateField;
            }
            set
            {
                this.x509CertificateField = value;
            }
        }

        /// <remarks/>
        public string X509SubjectName
        {
            get
            {
                return this.x509SubjectNameField;
            }
            set
            {
                this.x509SubjectNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfoKeyValue
    {

        private SignatureKeyInfoKeyValueRSAKeyValue rSAKeyValueField;

        /// <remarks/>
        public SignatureKeyInfoKeyValueRSAKeyValue RSAKeyValue
        {
            get
            {
                return this.rSAKeyValueField;
            }
            set
            {
                this.rSAKeyValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfoKeyValueRSAKeyValue
    {

        private string modulusField;

        private string exponentField;

        /// <remarks/>
        public string Modulus
        {
            get
            {
                return this.modulusField;
            }
            set
            {
                this.modulusField = value;
            }
        }

        /// <remarks/>
        public string Exponent
        {
            get
            {
                return this.exponentField;
            }
            set
            {
                this.exponentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureObject
    {

        private QualifyingProperties qualifyingPropertiesField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public QualifyingProperties QualifyingProperties
        {
            get
            {
                return this.qualifyingPropertiesField;
            }
            set
            {
                this.qualifyingPropertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://uri.etsi.org/01903/v1.3.2#", IsNullable = false)]
    public partial class QualifyingProperties
    {

        private QualifyingPropertiesSignedProperties signedPropertiesField;

        private string targetField;

        /// <remarks/>
        public QualifyingPropertiesSignedProperties SignedProperties
        {
            get
            {
                return this.signedPropertiesField;
            }
            set
            {
                this.signedPropertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedProperties
    {

        private QualifyingPropertiesSignedPropertiesSignedSignatureProperties signedSignaturePropertiesField;

        private QualifyingPropertiesSignedPropertiesSignedDataObjectProperties signedDataObjectPropertiesField;

        private string idField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignatureProperties SignedSignatureProperties
        {
            get
            {
                return this.signedSignaturePropertiesField;
            }
            set
            {
                this.signedSignaturePropertiesField = value;
            }
        }

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedDataObjectProperties SignedDataObjectProperties
        {
            get
            {
                return this.signedDataObjectPropertiesField;
            }
            set
            {
                this.signedDataObjectPropertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignatureProperties
    {

        private System.DateTime signingTimeField;

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificate signingCertificateField;

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole signerRoleField;

        /// <remarks/>
        public System.DateTime SigningTime
        {
            get
            {
                return this.signingTimeField;
            }
            set
            {
                this.signingTimeField = value;
            }
        }

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificate SigningCertificate
        {
            get
            {
                return this.signingCertificateField;
            }
            set
            {
                this.signingCertificateField = value;
            }
        }

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole SignerRole
        {
            get
            {
                return this.signerRoleField;
            }
            set
            {
                this.signerRoleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificate
    {

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCert certField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCert Cert
        {
            get
            {
                return this.certField;
            }
            set
            {
                this.certField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCert
    {

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertCertDigest certDigestField;

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertIssuerSerial issuerSerialField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertCertDigest CertDigest
        {
            get
            {
                return this.certDigestField;
            }
            set
            {
                this.certDigestField = value;
            }
        }

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertIssuerSerial IssuerSerial
        {
            get
            {
                return this.issuerSerialField;
            }
            set
            {
                this.issuerSerialField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertCertDigest
    {

        private DigestMethod digestMethodField;

        private string digestValueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public DigestMethod DigestMethod
        {
            get
            {
                return this.digestMethodField;
            }
            set
            {
                this.digestMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string DigestValue
        {
            get
            {
                return this.digestValueField;
            }
            set
            {
                this.digestValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class DigestMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertIssuerSerial
    {

        private string x509IssuerNameField;

        private ulong x509SerialNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string X509IssuerName
        {
            get
            {
                return this.x509IssuerNameField;
            }
            set
            {
                this.x509IssuerNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public ulong X509SerialNumber
        {
            get
            {
                return this.x509SerialNumberField;
            }
            set
            {
                this.x509SerialNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole
    {

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles claimedRolesField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles ClaimedRoles
        {
            get
            {
                return this.claimedRolesField;
            }
            set
            {
                this.claimedRolesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles
    {

        private string claimedRoleField;

        /// <remarks/>
        public string ClaimedRole
        {
            get
            {
                return this.claimedRoleField;
            }
            set
            {
                this.claimedRoleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedDataObjectProperties
    {

        private QualifyingPropertiesSignedPropertiesSignedDataObjectPropertiesDataObjectFormat dataObjectFormatField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedDataObjectPropertiesDataObjectFormat DataObjectFormat
        {
            get
            {
                return this.dataObjectFormatField;
            }
            set
            {
                this.dataObjectFormatField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedDataObjectPropertiesDataObjectFormat
    {

        private string mimeTypeField;

        private string objectReferenceField;

        /// <remarks/>
        public string MimeType
        {
            get
            {
                return this.mimeTypeField;
            }
            set
            {
                this.mimeTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ObjectReference
        {
            get
            {
                return this.objectReferenceField;
            }
            set
            {
                this.objectReferenceField = value;
            }
        }
    }



    public class UyumsoftXML
    {
    }
}
