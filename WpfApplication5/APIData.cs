using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG
{
    public class APIJsonReference
    {
        public class _authorize : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _authorize()
            {
                Response = new string[] { "APIKey", "ValidUntil" };
                JSONExample = @"{
""Username"": ""admin"",
""Password"": ""$WebSDKPassword""
}";
            }
        }
        public class _authorize_checkvalid : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _authorize_checkvalid()
            {
                Response = new string[] { "APIKey", "ValidUntil" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _certificates_renew : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _certificates_renew()
            {
                Response = new string[] { "Success", "Error" };
                JSONExample = @"{
""CertificateDN"": ""\\VED\\Policy\\Marketing\\Zoey""
}";
            }
        }
        public class _certificates_request : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _certificates_request()
            {
                Response = new string[] { "CertificateDN", "Error" };
                JSONExample = @"{
""PolicyDN"": ""\\VED\\Policy\\Mktg Certificates"",
""CADN"": ""\\VED\\Policy\\Operational Objects\\MS CA"",
""Subject"": ""www.venafi.com"",
""CASpecificAttributes"": [
{
""Name"": ""Validity Period"",
""Value"": ""365""
}
],
""SubjectAltNames"": [
{
""Type"": 2,
""Name"": ""www1.venafi.com""
}
]
}";
            }
        }
        public class _certificates_retrieve : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _certificates_retrieve()
            {
                Response = new string[] { "CertificateData", "Format", "Filename" };
                JSONExample = @"{
""CertificateDN"": ""\\VED\\Policy\\www.venafi.com"",
""Format"": ""Base64""
}";
            }
        }
        public class _certificates_revoke : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _certificates_revoke()
            {
                Response = new string[] { "Name", "Revoked", "Requested", "Success","Error" };
                JSONExample = @"{
""Thumbprint"": ""1f3fa666194cdc5119d23cac192f3706b16a7977"",
""Reason"": 2,
""Comments"": ""Blah""
}";
            }
        }
        public class _certificates : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _certificates()
            {
                Response = new string[] { "Certificates",
                    "Certificates.CreatedOn",
                    "Certificates.DN",
                    "Certificates.Guid",
                    "Certificates.Name",
                    "Certificates.ParentDN",
                    "Certificates.SchemaClass",
                    "Certificates._links",
                    "Certificates._links.Details",
                    "DataRange",
                    "TotalCount"
                };
                JSONExample = @"{
""CertificateDN"": ""\\VED\\Policy\\Marketing\\Zoey""
}";
            }
        }
        public class _config_adddnvalue : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_adddnvalue()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Certificate"",
""AttributeName"": ""Consumers"",
""Value"": ""\\VED\\Policy\\folder\\Device 2\\Basic 1""
}";
            }
        }
        public class _config_addpolicyvalue : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_addpolicyvalue()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\TestPolicy"",
""Class"": ""X509 Certificate"",
""AttributeName"":
""Organization"",
""Value"": ""Testing"",
""Locked"": false
}";
            }
        }
        public class _config_addvalue : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_addvalue()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 3"",
""AttributeName"": ""Description"",
""Value"": ""Description 3""
}";
            }
        }
        public class _config_clearattribute : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_clearattribute()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 3"",
""AttributeName"": ""Description""
}";
            }
        }
        public class _config_clearpolicyattribute : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_clearpolicyattribute()
            {
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\TestPolicy"", ""Class"": ""X509 Certificate"",
""AttributeName"": ""Management Type""
}";
            }
        }
        public class _config_containableclasses : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_containableclasses()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder""
}";
            }
        }
        public class _config_create : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_create()
            {
                Response = new string[] { "Object","Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\Auto\\Devices\\SSLServer01"",
""Class"": ""Device"",
""NameAttributeList"": [
{
""Value"": ""Auto-generated according to Service Request #12345"",""Name"": ""Description""
},
{
""Value"": ""sslserver01.myexamplecompany.com"",
""Name"": ""Host""
}";
            }
        }
        public class _config_defaultdn : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_defaultdn()
            {
                Response = new string[] { "DefaultDN","Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _config_delete : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_delete()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\Testdevice""
}";
            }
        }
        public class _config_dntoguid : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_dntoguid()
            {
                Response = new string[] { "ClassName", "GUID","Revision", "HierarchicalGUID", "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 2""
}";
            }
        }
        public class _config_enumerate : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_enumerate()
            {
                Response = new string[] { "Objects", "Result" };
                JSONExample = @"{
""Recursive"": ""true"",
""ObjectDN"": ""\\VED\\Policy\\folder""
}";
            }
        }
        public class _config_enumerateall : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_enumerateall()
            {
                Response = new string[] { "Objects", "Result" };
                JSONExample = @"{
""Pattern"": ""*devi*""
}";
            }
        }
        public class _config_enumeratefolders : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_enumeratefolders()
            {
                Response = new string[] {  "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _config_enumerateobjectsderivedfrom : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_enumerateobjectsderivedfrom()
            {
                Response = new string[] { "Objects", "Result" };
                JSONExample = @"{
""DerivedFrom"": ""Credential Base"",
}";
            }
        }
        public class _config_enumeratepolicies : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_enumeratepolicies()
            {
                Response = new string[] { "Policies", "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\TestFolder""
} ";
            }
        }
        public class _config_find : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_find()
            {
                Response = new string[] { "Objects", "Result" };
                JSONExample = @"{
""Pattern"": ""*escri*"",
""AttributeNames"": [
""Description"",
""Credential""
]
}";
            }
        }
        public class _config_findcontainers : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_findcontainers()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder""
}";
            }
        }
        public class _config_findfolders : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_findfolders()
            {
                Response = new string[] { "Objects", "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder""
}";
            }
        }
        public class _config_findobjectsofclass : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_findobjectsofclass()
            {
                Response = new string[] { "Objects",
                    "Objects.AbsoluteGUID",
                    "Objects.DN",
                    "Objects.GUID",
                    "Objects.Id",
                    "Objects.Name",
                    "Objects.Parent",
                    "Objects.Revision",
                    "Objects.TypeName",
                    "Result" };
                JSONExample = @"{
""Pattern"": ""*evi*"",
""Classes"": [
""Device"",
""User""
]
}";
            }
        }
        public class _config_findpolicy : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_findpolicy()
            {
                Response = new string[] { "PolicyDN","Locked","Values","Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\TestCert"",
""Class"": ""X509 Certificate"",
""AttributeName"": ""Management Type""
}";
            }
        }
        public class _config_gethighestrevision : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_gethighestrevision()
            {
                Response = new string[] { "Revision", "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder"",
""Classes"": [
""Policy""
]
}";
            }
        }
        public class _config_getrevision : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_getrevision()
            {
                Response = new string[] { "Revision", "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder""
}";
            }
        }
        public class _config_guidtodn : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_guidtodn()
            {
                Response = new string[] { "ObjectDN","ClassName","Revision", "HierarchicalGUID", "Result" };
                JSONExample = @"{
""ObjectGUID"": ""{c7fdd8d1-1fb2-4cd0-a041-9a020245a6df}""
}";
            }
        }
        public class _config_isvalid : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_isvalid()
            {
                Response = new string[] { "Object", "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 2""
}";
            }
        }
        public class _config_mutateobject : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_mutateobject()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 2"",
""Class"": ""Apache""
}";
            }
        }
        public class _config_read : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_read()
            {
                Response = new string[] { "Values","Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 3"",
""AttributeName"": ""Description""
}";
            }
        }
        public class _config_readall : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_readall()
            {
                Response = new string[] { "NameValues","Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 3""
}";
            }
        }
        public class _config_readdn : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_readdn()
            {
                Response = new string[] { "Values","Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Certificate"",
""AttributeName"": ""Consumers""
}";
            }
        }
        public class _config_readdnreferences : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_readdnreferences()
            {
                Response = new string[] { "Values","Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\TestDevice\\TestApp"",
""ReferenceAttributeName"": ""Certificate"",
""AttributeName"": ""Certificate Authority""
}";
            }
        }
        public class _config_readeffectivepolicy : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_readeffectivepolicy()
            {
                Response = new string[] { "Values","Overridden","PolicyDN","Locked","Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 3"",
""AttributeName"": ""Description""
}";
            }
        }
        public class _config_readpolicy : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_readpolicy()
            {
                Response = new string[] { "Values","Locked","Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\TestPolicy"",
""AttributeName"": ""Network Validation Disabled""
""Class"": ""JKS""
""Values"": ""1""
]
}";
            }
        }
        public class _config_removeattributevalues : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_removeattributevalues()
            {
                Response = new string[] { "Count"};
                JSONExample = @"{
""Pattern"": ""Failure*""
}";
            }
        }
        public class _config_removednvalue : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_removednvalue()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Certificate"",
""AttributeName"": ""Consumers"",
""Value"": ""\\VED\\Policy\\folder\\Device 2\\Basic 1""
}";
            }
        }
        public class _config_removepolicyvalue : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_removepolicyvalue()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\TestPolicy"",
""Class"": ""X509 Certificate"",
""AttributeName"": ""City"",
""Value"": ""Sandy""
}";
            }
        }
        public class _config_removevalue : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_removevalue()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Certificate"",
""AttributeName"": ""Description"",
""Value"": ""Description 1""
}";
            }
        }
        public class _config_renameobject : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_renameobject()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Device 2\\Basic 2"",
""NewObjectDN"": ""\\VED\\Policy\\folder\\Device 1\\Basic 2""
}";
            }
        }
        public class _configrights_getobjectrights : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _configrights_getobjectrights()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _configrights_getobjecttrustees : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _configrights_getobjecttrustees()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _configrights_grantobjectrights : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _configrights_grantobjectrights()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _configrights_removeobjectrights : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _configrights_removeobjectrights()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _config_write : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_write()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Discovery\\Private Networks"",
""AttributeName"": ""Address Range"",
""Values"": [
""192.168.1.1-192.168.1.254:443,7002"",
""192.168.100.1-192.168.100.254:443,7002""
]
}";
            }
        }
        public class _config_writedn : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_writedn()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\Certificate"",
""AttributeName"": ""Consumers"",
""Values"": [
""\\VED\\Policy\\folder\\Device 2\\Basic 1"",
""\\VED\\Policy\\folder\\Device 2\\Basic 3""
]
}";
            }
        }
        public class _config_writepolicy : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _config_writepolicy()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""Locked"": true,
""ObjectDN"": ""\\VED\\Policy\\TestPolicy"",
""Class"": ""JKS"",
""AttributeName"": ""Key Store"",
""Values"": [
""/etc/crypto/common.jks""
]
}";
            }
        }
        public class _credentials_create : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _credentials_create()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""CredentialPath"": ""\\VED\\Policy\\MyUsernameCred"",
""FriendlyName"":
""UsernamePassword"",
""Expiration"": ""\/Date(1716122248657)\/"",
""Values"": [    
{     
""Name"": ""Username"",
""Type"": ""string"",
""Value"": ""service-account""
},
{ 
""Name"": ""Password"",
""Type"": ""string"", ""Value"":
""Str0ngP@ssw0rd!""
}
]
}";
            }
        }
        public class _credentials_delete : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _credentials_delete()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""CredentialPath"": ""\\VED\\Policy\\Renamed Password Cred""
}";
            }
        }
        public class _credentials_deletecontainer : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _credentials_deletecontainer()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""CredentialPath"": ""\\VED\\Policy\\Test Password Credential container""
}";
            }
        }
        public class _credentials_enumerate : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _credentials_enumerate()
            {
                Response = new string[] { "CredentialInfos", "Result" };
                JSONExample = @"{
""CredentialPath"": ""\\VED\\Policy"",
""Pattern"": null,
""Recursive"": false
}";
            }
        }
        public class _credentials_rename : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _credentials_rename()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""CredentialPath"": ""\\VED\\Policy\\Test Password Credential"",
""NewCredentialPath"": ""\\VED\\Policy\\Renamed Password Cred""
} ";
            }
        }
        public class _credentials_renamecontainer : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _credentials_renamecontainer()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""CredentialPath"": ""\\VED\\Policy\\Test Password Credential container"",
""NewCredentialPath"": ""\\VED\\Policy\\Renamed Password Cred container""
}";
            }
        }
        public class _credentials_retrieve : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _credentials_retrieve()
            {
                Response = new string[] { "CredentialPath" };
                JSONExample = @"{
""CredentialPath"": ""\\VED\\Policy\\Test Password Credential""
}";
            }
        }
        public class _credentials_update : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _credentials_update()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""Description"": ""test description"",
""Shared"": false,
""FriendlyName"": ""Password"",
""Values"": [
{
""Name"": ""Password"",
""Type"": ""string"",
""Value"": ""updated password""
}
],
""CredentialPath"": ""\\VED\\Policy\\Test Password Credential""
}";
            }
        }
        public class _crypto_availablekeys : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _crypto_availablekeys()
            {
                Response = new string[] { "Keynames" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _crypto_defaultkey : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _crypto_defaultkey()
            {
                Response = new string[] { "DefaultKey" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _identity_browse : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _identity_browse()
            {
                Response = new string[] { "Identities" };
                JSONExample = @"{
""Filter"": ""BIll"",
""Limit"": 50,
""IdentityType"": 3
}";
            }
        }
        public class _identity_getassociatedentries : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _identity_getassociatedentries()
            {
                Response = new string[] { "Identities" };
                JSONExample = @"{  ""ID"": {     ""Prefix"": ""local"", ""Name"":
""Admin"", ""FullName"": ""\\VED\\Identity\\Admin"", ""Universal"": ""{dbc923e3-6cb5-4533-a3b4-
6dbb8f18f954}"", ""IsGroup"": false, ""Isfolder"": false  } }";
            }
        }
        public class _identity_getmembers : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _identity_getmembers()
            {
                Response = new string[] { "Identities" };
                JSONExample = @"{
""ID"": {
""Prefix"": ""local"",
""Name"": ""Everyone"",
""FullName"": ""\\VED\\Identity\\Everyone"",
""Universal"": ""{59b4e049-14ac-47b2-8f92-97847d9424bb}"",
""IsGroup"": true,
""Isfolder"": false
},
""ResolveNested"": 1
}";
            }
        }
        public class _identity_getmemberships : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _identity_getmemberships()
            {
                Response = new string[] { "Identities" };
                JSONExample = @"{
""ID"": {
""Prefix"": ""local"",
""Name"": ""Supervisor"",
""FullName"": ""\\VED\\Identity\\Supervisor"",
""Universal"": ""{59b4e049-14ac-47b2-8f92-97847d9424bb}"",
""IsGroup"": false,
""Isfolder"": false
} }";
            }
        }
        public class _identity_readattribute : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _identity_readattribute()
            {
                Response = new string[] { "Attribute" };
                JSONExample = @"{
""ID"": {
""Prefix"": ""local"",
""Name"": ""Admin"",
""FullName"": ""\\VED\\Identity\\Admin"",
""Universal"": ""{dbc923e3-6cb5-4533-a3b4-6dbb8f18f954}"",
""IsGroup"": false,
""Isfolder"": false
},
""AttributeName"": ""Surname""
}";
            }
        }
        public class _identity_self : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _identity_self()
            {
                Response = new string[] { "Identities" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _identity_validate : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _identity_validate()
            {
                Response = new string[] { "ID" };
                JSONExample = @"{
""ID"": {
""Prefix"": ""local"",
""Name"": null,
""FullName"": null,
""Universal"": ""{dbc923e3-6cb5-4533-a3b4-6dbb8f18f954}"",
""IsGroup"": false,
""Isfolder"": false
}
}";
            }
        }
        public class _log : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _log()
            {
                Response = new string[] { "LogResult" };
                JSONExample = @"{
""ID"": 786436,
""EventId"": 10,
""Severity"": 7,
""GroupId"": 10,
""SourceIp"": 9.5.45.11,
""Component"": ""\\VED\\Policy\\TestCert"",
""ComponentID"": 2,
""ComponentSubsystem"": ""Config"",
""Text1"": ""local:{dbc923e3-6cb5-4533-a3b4-6dbb8f18f954}"",
""Text2"": ""X509 Certificate"",
""Value1"": 1,
""Value2"": 2,
""Grouping"": 123
}";
            }
        }
        public class _metadata_defineitem : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_defineitem()
            {
                Response = new string[] { "DN","Item","Result" };
                JSONExample = @"{
""Item"": { 
""Label"": ""Cost Center"",
""Name"": ""Hidden Object Name"", 
""Classes"": [ ""X509 Certificate"", ""Device"" ],
""Type"": 1
}
}";
            }
        }
        public class _metadata_find : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_find()
            {
                Response = new string[] { "Objects","Result" };
                JSONExample = @"{
""ItemGuid"": ""{a80714f0-565c-4bc2-9026-787cf076d764}""
}";
            }
        }
        public class _metadata_finditem : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_finditem()
            {
                Response = new string[] { "ItemGuid","Result" };
                JSONExample = @"{
""Name"": ""Cost Center""
} ";
            }
        }
        public class _metadata_get : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_get()
            {
                Response = new string[] { "Data","Result" };
                JSONExample = @"{
""DN"": ""\\VED\\Policy\\Certificates\\www.company.com""
}";
            }
        }
        public class _metadata_getitemguids : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_getitemguids()
            {
                Response = new string[] { "ItemGuids","Result" };
                JSONExample = @"{
""DN"": ""\\VED\\Policy\\Certificates\\www.company.com""
} ";
            }
        }
        public class _metadata_getpolicyitems : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_getpolicyitems()
            {
                Response = new string[] { "PolicyItems","Result" };
                JSONExample = @"{
""DN"": ""\\VED\\Policy\\Certificates""
} ";
            }
        }
        public class _metadata_items : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_items()
            {
                Response = new string[] { "Items" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _metadata_readeffectivevalues : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_readeffectivevalues()
            {
                Response = new string[] { "Locked","Overridden","PolicyDn","Values","Result" };
                JSONExample = @"{
""DN"": ""\\VED\\Policy\\Certificates\\www.company.com"", ""ItemGuid"": ""{a80714f0-565c-4bc2-9026-
787cf076d764}"" }";
            }
        }
        public class _metadata_readpolicy : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_readpolicy()
            {
                Response = new string[] { "Locked","Values","Result" };
                JSONExample = @"{         
""DN"": ""\\VED\\Policy\\Certificates"",
""ItemGuid"": ""{a80714f0-565c-4bc2-9026-787cf076d764}"",
""Type"": ""X509 Certificate""
}";
            }
        }
        public class _metadata_set : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_set()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""DN"": ""\\VED\\Policy\\Certificates\\www.company.com""
}";
            }
        }
        public class _metadata_setpolicy : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_setpolicy()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""DN"": ""\\VED\\Policy\\Certificates"", ""ConfigClass"": ""X509 Certificate"",
""Locked"": true, ""GuidData"": [ { ""ItemGuid"": ""{a80714f0-565c-4bc2-9026-787cf076d764}"", ""List"":
[ ""XYZ789""
]
} ] }";
            }
        }
        public class _metadata_undefineitem : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_undefineitem()
            {
                JSONExample = @"{
""ItemGuid"": ""{a80714f0-565c-4bc2-9026-787cf076d764}"" ""RemoveData"": true
}";
            }
        }
        public class _metadata_updateitem : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _metadata_updateitem()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""Item"": {
""DN"": ""\\VED\\Metadata Root\\Hidden Object Name"",
""Guid"": ""{a80714f0-565c-4bc2-9026-787cf076d764}"",
""Label"": ""Cost Center"",
""Classes"": [ ""X509 Certificate"" ],
""Mandatory"": true,
""Policyable"": true,
""Type"": 1,
""RegularExpression"": ""[A-Za-z]{3}[0-9]{3}"",
""ErrorMessage"": ""Value entered is not a valid Cost Center"",
""Help"": ""Cost Center is comprised of 3 letters followed by 3 numbers""
}""
}";
            }
        }
        public class _permissions_object : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _permissions_object()
            {
                Response = new string[] { "List" };
                JSONExample = @"{
""IsAssociateAllowed"":false,
""IsCreateAllowed"":false,
""IsDeleteAllowed"":false,
""IsManagePermissionsAllowed"":false,
""IsPolicyWriteAllowed"":false,
""IsPrivateKeyReadAllowed"":true,
""IsPrivateKeyWriteAllowed"":true,
""IsReadAllowed"":true,
""IsRenameAllowed"":false,
""IsRevokeAllowed"":false,
""IsViewAllowed"":true,
""IsWriteAllowed"":true,
}";
            }
        }
        public class _rights_add : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_add()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_find : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_find()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_get : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_get()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_getright : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_getright()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_gettoken : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_gettoken()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_match : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_match()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_refresh : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_refresh()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_remove : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_remove()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_removeall : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_removeall()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _rights_removeallbyprefix : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _rights_removeallbyprefix()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _secretstore_add : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_add()
            {
                Response = new string[] { "Result","ValultID" };
                JSONExample = @"{
""VaultType"": 32,
""Keyname"": ""DPAPI:Default"",
""Base64Data"": ""cGFzc3cwcmQ="",
""Namespace"": ""config"",
""Owner"": ""\\VED\\Policy\\LogonCredential""
}";
            }
        }
        public class _secretstore_associate : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_associate()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""VaultID"": 376,
""Name"": ""Purpose"",
""StringValue"": ""Access to endpoint""
}";
            }
        }
        public class _secretstore_delete : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_delete()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""VaultID"": 376
}";
            }
        }
        public class _secretstore_dissociate : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_dissociate()
            {
                Response = new string[] { "Result" };
                JSONExample = @"{
""VaultID"": 376,
""Name"": ""Purpose""
}";
            }
        }
        public class _secretstore_encryptionkeysinuse : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_encryptionkeysinuse()
            {
                Response = new string[] { "EncryptionKeys","Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _secretstore_lookup : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_lookup()
            {
                Response = new string[] { "VaultIDs","Result" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _secretstore_lookupbyassociation : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_lookupbyassociation()
            {
                Response = new string[] { "VaultIDs","Result" };
                JSONExample = @"{
""Name"": ""Serial"",
""StringValue"": ""5932C68AC336321AC18952C2F0E4CC9C""
}";
            }
        }
        public class _secretstore_lookupbyowner : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_lookupbyowner()
            {
                Response = new string[] { "VaultIDs","Result" };
                JSONExample = @"{
""Namespace"": ""config"",
""Owner"": ""\\VED\\Identity\\NoRightsUser""
}";
            }
        }
        public class _secretstore_lookupbyvaulttype : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_lookupbyvaulttype()
            {
                Response = new string[] { "VaultIDs","Result" };
                JSONExample = @"{
""VaultType"": 16
}";
            }
        }
        public class _secretstore_mutate : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_mutate()
            {
                Response = new string[] {"Result" };
                JSONExample = @"{
""VaultID"": 1073741826,
""VaultType"": 6
}";
            }
        }
        public class _secretstore_orphanlookup : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_orphanlookup()
            {
                Response = new string[] { "VaultIDs","Result" };
                JSONExample = @"{
""VaultType"": 6
}";
            }
        }
        public class _secretstore_owneradd : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_owneradd()
            {
                Response = new string[] {"Result" };
                JSONExample = @"{
""VaultID"": 376,
""Namespace"": ""config"",
""Owner"": ""\\VED\\Policy\\AnotherCredential""
}";
            }
        }
        public class _secretstore_ownerdelete : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_ownerdelete()
            {
                Response = new string[] {"Result" };
                JSONExample = @"{
""VaultID"": 376,
""Namespace"": ""config"",
""Owner"": ""\\VED\\Policy\\AnotherCredential""
}";
            }
        }
        public class _secretstore_ownerlookup : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_ownerlookup()
            {
                Response = new string[] {"Owners","Result" };
                JSONExample = @"{
""VaultID"": 376,
""Namespace"": ""config""
}";
            }
        }
        public class _secretstore_retrieve : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _secretstore_retrieve()
            {
                Response = new string[] {"Base64Data","ValutType","Result" };
                JSONExample = @"{
""VaultID"": 376
}";
            }
        }
        public class _ssh_addauthorizedkey : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_addauthorizedkey()
            {
                Response = new string[] {"KeyId","Response" };
                JSONExample = @"{ 
""DeviceGuid"":""{21a8574c-f448-4a8c-aa13-cbd6a07df49b}"",
""Username"":""user"",
""Filepath"":""/home/user/.ssh/authorized_keys"",
""Format"":""OpenSSH"",
""KeysetId"":""953C85736E1D254E60AB4F8665239D942157FAF6""
}";
            }
        }
        public class _ssh_addknownhostkey : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_addknownhostkey()
            {
                Response = new string[] {"KeyId","Response" };
                JSONExample = @"{ 
""DeviceGuid"":""{21a8574c-f448-4a8c-aa13-cbd6a07df49b}"",
""Username"":""user"",
""Filepath"":""/home/user/.ssh/known_hosts"",
""Format"":""OpenSSH"",
""KeysetId"":""7FAF6953C85736E1D254E60AB4F8665239D94215""
}";
            }
        }
        public class _ssh_adduserprivatekey : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_adduserprivatekey()
            {
                Response = new string[] {"KeyId","KeysetId","Response" };
                JSONExample = @"{ 
""DeviceGuid"":""{21a8574c-f448-4a8c-aa13-cbd6a07df49b}"",
""Username"":""user"",
""Filepath"":""/home/user/.ssh/user.key"",
""Format"":""OpenSSH"",
""Passphrase"":""Hf5e@rj4kf%r""
}";
            }
        }
        public class _ssh_cancelkeyoperation : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_cancelkeyoperation()
            {
                Response = new string[] {"Response" };
                JSONExample = @"{
""KeyId"" : 59
}";
            }
        }
        public class _ssh_cancelrotation : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_cancelrotation()
            {
                Response = new string[] {"Response" };
                JSONExample = @"{
""KeysetId"" : ""70AF05FAB7910CD923EB98B003110930F68D5EC6""
}";
            }
        }
        public class _ssh_devices : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_devices()
            {
                Response = new string[] { "SshDeviceData" };
                JSONExample = @"{
""PageSize"" : 20,
""Offset"" : 0,
""SshDeviceFilter"":{""DeviceName"":[""myserver""]}
}";
            }
        }
        public class _ssh_importauthorizedkey : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_importauthorizedkey()
            {
                Response = new string[] { "KeyId","SshDeviceData" };
                JSONExample = @"{
""KeyContentBase64"" :
""c3NoLXJzYSBBQUFBQjNOemFDMXljMkVBQUFBREFRQUJBQUFCQVFETW5IOGw2VnU1K2x
2Tno4VnFMc0JibkpIejFKdStRNXpUOW5OU1VYUXJtOFUzNXloZHYxVDVqWC9haDlWU2s5Z2lQ
ZTZUSVUwdnpyS0JxR1BrcjV0QlRObjdvRlVSQXgvSm9JTkkvS3ozWU1ZRnkyL3lKenRLM0ttazdG
WXYvWUh2bElhdFd2K3BnRVpDRlZNY29tNFdoYXFGaUZMcExMUmMvOE1YRUxRWmJpSi9LM
3JRbHRNdDBoazRUY2xYc24zUi9jRDFsWHkwcjhTRXJFWHFZMzZ5SkFRNC94dndLYXJaSVBK
ay93Z25mUCtPZlcySHo5Z1NCNlFXa3E1YUZwUGxZTW5kc2ZiVCtMZHg4enJWWmdHb2E0VTdP
M0gxaXB2WjNYeUFkSWhDVHg3MG5DNExDMkQ0TTcrWFZVbHl0OWpVNHFCR3U4Vm9XbDR
Bc1UxbitBZVYgYW5kcmV5QGFuZHJleS12ZW5hZmk="",
""DeviceGuid"":""{21a8574c-f448-4a8c-aa13-cbd6a07df49b}"",
""Username"":""user"",
""Filepath"":""/db/authkey/5"",
""Format"":""OpenSSH""
}";
            }
        }
        public class _ssh_importprivatekey : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_importprivatekey()
            {
                Response = new string[] { "KeyId","SshDeviceData" };
                JSONExample = @"{
""KeyContentBase64"" : ""
LS0tLS1CRUdJTiBSU0EgUFJJVkFURSBLRVktLS0tLQ0KTUlJQnlnSUJBQUpoQU1xek0zTWNaR
2hmTzhCeGRXZldXUGFMY3Zkc29oNmxaVjlHdWZyMTZKbVA1Z1loU0Fybw0KNG1uanNlcFMxcV
lGclowcnlXM2M0cVhSaS9xME1Cd3N3VCt0SWxGNzl6SFNaOTIzVytsQ0FuY1ZZekhSbE1MVA0K
c3FaUGZBSE0vWkNMQXdJREFRQUJBbUJydTNMTTYzb3lQdXR6RE5wcHBmTUNsbnMwSmZq
RWNRTy83OGRKS3duRg0KRkVZZFcvTCtXV2g4L3hmQWd1YXl0ckR0UlJYK0lNckljdWlUcFZuLy
81VW4xOHJ0NVphcjR0LzZsMnl4WE1tMw0KU0JPVHJuN2V0UWkvM1ZFWFpWbitlWUVDTVFEd
U5vYzFHc2ZZdGw1N1JLUm5vZ3hLdUJKdzhzN0p2VzlLY3NoRQ0KaGpMcERiWVhvT0htWUl3dV
pPSi8wWUJKK0djQ01RRFoxZFpkZzlVZVF5YmRTa2s1MG1hVjJORy9CSmpRalV5Tw0KS0M3clZ
sMDVkNm1iRHBQMGFQdUN6dGMxbmY0aEp3VUNNUURid0gzV3BZLzdBYklEY1gxaEJRTGw0d
zFRR1E1ZQ0KMlZ6VGh6UHMwd2dnS3IveTZEMjlNdy9ldEw2bVAzUmp5TDBDTURUY3o4aWgx
WFlpbGF2ZCt5Y3RCL2dWUmRFMQ0KTEdCdjZjUVZ2RTBnQ0QrSjZuN1dhdEZGS01QMXJnUTA
4eGJZZ1FJd05IQlRXWXh0MUMyT3FaVTdKUXFJMTFUYg0KUHZWbVJBaGxNT0JnYVpneGdpM
3gvN25Mb1RQQXY4RkhMR0JaVzJvZg0KLS0tLS1FTkQgUlNBIFBSSVZBVEUgS0VZLS0tLS0="",
""DeviceGuid"":""{21a8574c-f448-4a8c-aa13-cbd6a07df49b}"",
""Username"":""user"",
""Filepath"":""/db/privatekey/25"",
""Format"":""OpenSSH""
}";
            }
        }
        public class _ssh_keydetails : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_keydetails()
            {
                Response = new string[] { "KeyData"};
                JSONExample = @"{
""KeyId"" : [58]
}";
            }
        }
        public class _ssh_keysetdetails : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_keysetdetails()
            {
                Response = new string[] { "KeysetData"};
                JSONExample = @"{
""KeysetFilter"" : {
""Algorithm"" : [ ""ssh-rsa"" ]
},
""PageSize"" : 20,
""Offset"" : 0,
""LoadKeyData"" : true
}";
            }
        }
        public class _ssh_removekey : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_removekey()
            {
                Response = new string[] {"Response" };
                JSONExample = @"{
""KeyId"" : 61,
""AllowedSourceRestriction"" : [""192.168.1.*"", ""192.168.2.*""],
""DeniedSourceRestriction"" : [""192.168.1.1"", ""192.168.2.1""],
""ForcedCommand"" : ""echo 'SSH connected'"",
""Options"" : [""no-pty"", ""no-port-forwarding""]
}";
            }
        }
        public class _ssh_retrykeyoperation : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_retrykeyoperation()
            {
                Response = new string[] {"Response" };
                JSONExample = @"{
""KeyId"" : 59
}";
            }
        }
        public class _ssh_retryrotation : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_retryrotation()
            {
                Response = new string[] {"Response" };
                JSONExample = @"{
""KeysetId"" : ""70AF05FAB7910CD923EB98B003110930F68D5EC6""
}";
            }
        }
        public class _ssh_rotate : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_rotate()
            {
                Response = new string[] {"Response" };
                JSONExample = @"{
""KeysetId"" : ""70AF05FAB7910CD923EB98B003110930F68D5EC6""
}";
            }
        }
        public class _ssh_widget_stats : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _ssh_widget_stats()
            {
                Response = new string[] {"Name Value Pairs" };
                JSONExample = @"{""RequestMethod"":""Get - No JSON values passed""}";
            }
        }
        public class _workflow_ticket_create : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _workflow_ticket_create()
            {
                Response = new string[] {"Result","GUID" };
                JSONExample = @"{
""ObjectDN"": ""\\VED\\Policy\\folder\\TestCert"",
""Reason"": 1,
""UserData"": ""This ticket was created by the WebSDK""
}";
            }
        }
        public class _workflow_ticket_delete : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _workflow_ticket_delete()
            {
                Response = new string[] {"Result" };
                JSONExample = @"{ 
""GUID"": ""af415f09-d487-43de-ba2e-f61d089b4e68""
}";
            }
        }
        public class _workflow_ticket_details : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _workflow_ticket_details()
            {
                Response = new string[] {"ApprovalExplanation","ApprovalFrom","ApprovalReason","Blocking","Created","IssuedDueTo","Status","Updated","Result" };
                JSONExample = @"{
""GUID"": ""af415f09-d487-43de-ba2e-f61d089b4e68"" }";
            }
        }
        public class _workflow_ticket_enumerate : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _workflow_ticket_enumerate()
            {
                Response = new string[] {"Result","GUIDs" };
                JSONExample = @"{
}";
            }
        }
        public class _workflow_ticket_exists : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _workflow_ticket_exists()
            {
                Response = new string[] {"Result" };
                JSONExample = @"{
""GUID"": ""6ede0e12-f7c0-4068-9977-001076205c84""
}";
            }
        }
        public class _workflow_ticket_status : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _workflow_ticket_status()
            {
                Response = new string[] {"Status","Result" };
                JSONExample = @"{
""GUID"": ""6ede0e12-f7c0-4068-9977-001076205c84""
}";
            }
        }
        public class _workflow_ticket_updatestatus : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _workflow_ticket_updatestatus()
            {
                Response = new string[] {"Result" };
                JSONExample = @"{
""GUID"": ""6ede0e12-f7c0-4068-9977-001076205c84"",
""Status"": ""Approved"",
""Explanation"": ""Ticket was approved by Joe""
} ";
            }
        }
        public class _x509certificatestore_add : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _x509certificatestore_add()
            {
                Response = new string[] {"VaultId","LeafExisted","Result" };
                JSONExample = @"{
""CertificateString"":
""MIIBKDCB06ADAgECAgkA74d8idwbXx8wDQYJKoZIhvcNAQEFBQAwGTEXMBUGA1UEAxMOd2Vic2Rr
LmV4YW1wbGUwHhcNMTMxMDEwMDA0OTM1WhcNMTQxMDEwMDA0OTM1WjAZMRcwFQYDVQQDEw53ZWJzZ
GsuZXhhbXBsZTBcMA0GCSqGSIb3DQEBAQUAA0sAMEgCQQCyYchKGgvQjdumy9j2kF5zK9VYjungMc
HXZ3VL3/mvM/rrj6OLLZgiYUMPtW9iANBn/eU8IXoomHfqGBXu7GrFAgMBAAEwDQYJKoZIhvcNAQE
FBQADQQB96zTXsYhGxhvXJyvDsVnNDr9RKgcZPeBF85iFS5qfiplnHq4weXSzTUQ/eOlND2hIlD/U
o45LOyid4ZKDpJNsMIIF5DCCBMygTo/ILxbX"",
""OwnerDN"": ""\\VED\\Policy\\folder\\TestCert"",
""TypedNameValues"": [
{
""Name"": ""Custom Purpose"",
""Type"": ""string"",
""Value"": ""Testing WebSDK""
}
]
}";
            }
        }
        public class _x509certificatestore_lookup : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _x509certificatestore_lookup()
            {
                Response = new string[] {"VaultId","VaultIds","CertificateCollection","Result" };
                JSONExample = @"{
""OwnerDN"": ""\\VED\\Policy\\folder\\TestCert""
}";
            }
        }
        public class _x509certificatestore_lookupexpiring : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _x509certificatestore_lookupexpiring()
            {
                Response = new string[] {"VaultId","Result" };
                JSONExample = @"{
""DaysToExpiration"": 1500,
""OwnerDN"": ""\\VED\\Policy\\folder\\TestCert""
}";
            }
        }
        public class _x509certificatestore_remove : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _x509certificatestore_remove()
            {
                Response = new string[] {"Result" };
                JSONExample = @"{
""VaultId"": 683,
""OwnerDN"": ""\\VED\\Policy\\folder\\TestCert""
}";
            }
        }
        public class _x509certificatestore_retrieve : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _x509certificatestore_retrieve()
            {
                Response = new string[] {"CertificateString","Result","TypedNameValues" };
                JSONExample = @"{
""VaultId"": 683
}";
            }
        }
        public class _configSchema_ContainableClasses : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _configSchema_ContainableClasses()
            {
                Response = new string[] {"ClassNames","Result" };
                JSONExample = @"{""Class"":""Device""}";
            }
        }
        public class _configSchema_Classes : IApiCall
        {
            public string JSONExample { get; }
            public string[] Response { get; }
            public _configSchema_Classes()
            {
                Response = new string[] { "ClassDefinitions", "Result" };
                JSONExample = @"{ ""DerivedFrom"": ""Application Base""}";
            }
        }
    }
}
