using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VSG
{
    public class AdaptableHelper
    {
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }
        public bool TrustSSL;
        public string[] GHT = new string[] {
            "HostAddress",
            "TcpPort",
            "UserName",
            "UserPass",
            "UserPrivKey",
            "AppObjectDN",
            "AssetName",
            "VarText1",
            "VarText2",
            "VarText3",
            "VarText4",
            "VarText5",
            "VarBool1",
            "VarBool2",
            "VarPass"
        };
        public Dictionary<string, List<string>> Specific = new Dictionary<string, List<string>>()
        {
            {"Approve-Request", new List<string>() {
                "TransId"
            } },
            {"Prepare-ForRequest", new List<string>() {
                "SubjectDN",
                "SubjAltNames"
            } },
            {"Retrieve-Certificate", new List<string>() {
                "CertId"
            } },
            {"Submit-CsrAsNew", new List<string>() {
                "Pkcs10",
                "SubjectDN",
                "SubjAltNames",
                "CertId",
                "CertPem"
            } },
            {"Submit-CsrAsRenewal", new List<string>() {
                "Pkcs10",
                "SubjectDN",
                "SubjAltNames",
                "CertId",
                "CertPem"
            } },
            {"Submit-CsrAsReplacement", new List<string>() {
                "Pkcs10",
                "SubjectDN",
                "SubjAltNames",
                "CertId",
                "CertPem"
            } },
            {"Revoke-Certificate", new List<string>() {
                "CertId",
                "CertPem",
                "ReasonCode",
                "Comment"
            } }
        };
        public string[] PSC = new string[] {
            "Invoke-WebRequest",
            "Invoke-RestMethod"
        };
        public string[] Methods = new string[] 
        {
            "POST",
            "GET",
            "PUT",
            "DELETE"
        };
        public string[] RequestType = new string[] 
        {
            "Json",
            "SOAP"
        };
        public string ParamBlock = "\tParam([Parameter(Mandatory=$true,HelpMessage=\"General Parameters\")]\r\n\t[System.Collections.Hashtable]$General,\r\n\t[Parameter(Mandatory=$false,HelpMessage=\"Function Specific Parameters\")]\r\n\t[System.Collections.Hashtable]$Specific)";
        public string SecurityType = @"[System.Net.ServicePointManager]::SecurityProtocol = `
            [System.Net.SecurityProtocolType]::Tls -bor `
            [System.Net.SecurityProtocolType]::Tls11 -bor `
            [System.Net.SecurityProtocolType]::Tls12";

        public Dictionary<string, string> FunctionDescription = new Dictionary<string, string>()
        {
            {"Test-Settings",@"<##################################################################################################
.NAME
    Test-Settings
.DESCRIPTION
    Verifies that Trust Protection Platform can authenticate with the CA using the supplied credentials.
.PARAMETER General
    A hashtable containing the general set of variables needed by all or most functions
		UserName: the username required to authenticate with the CA
		UserPass: the password required to authenticate with the CA
		PfxData: a PKCS#12 containing a client certificate and private key required to authenticate with the CA
		PfxPass: the password required to access the private key in the PKCS#12
		CertObjDN : the Venafi distinguished name of the certificate object in the policy tree
		CustomFields : the hash table of Custom Fields. Keys are field labels and values are either strings (single valued) or string arrays (multi-valued).
.NOTES
    Returns a hashtable that includes the following variables
        Result : 'Success' or 'NotUsed' to indicate the non-error completion state
##################################################################################################>"},
            { "Get-ChainCertificates", @"<##################################################################################################
.NAME
	Get-ChainCertificates
.DESCRIPTION
	Retrieves the chain of CA certificates that are applicable to certificates issued by the CA
.PARAMETER General
	A hash table containing the general set of variables needed by most (or all) functions (see Test-Settings)
.NOTES
	Returns a hashtable that includes the following variables:
		Result: 'Success' or 'NotUsed' to indicate the non-error completion state
		Pkcs7: a collection that includes all of the CA certificates in the issuing chain
##################################################################################################>" },
            { "Prepare-ForRequest", @"<##################################################################################################
.NAME
    Prepare-ForRequest
.DESCRIPTION
    Performs any tasks that are necessary to prior to submitting a certificate signing request to the CA
.PARAMETER General
    A hashtable containing the general set of variables needed by all or most functions (see Test-Settings)
.PARAMETER Specific
    A hashtable containing the specific set of variables needed by this function
        SubjectDN : the requested subject distiguished name as a hashtable; OU is a string array; all others are strings
        SubjAltNames : hashtable keyed by SAN type; values are string arrays
.NOTES
    Returns a hashtable that includes the following variables
        Result : 'Success' or 'NotUsed' to indicate the non-error completion state
##################################################################################################>"},
            { "Submit-CsrAsNew", @"<##################################################################################################
.NAME
	Submit-CsrAsNew
.DESCRIPTION
	Submits a CSR to a CA for enrollment as a new, first time certificate
.PARAMETER General
	A hash table containing the general set of variables needed by most (or all) functions (see Test-Settings)
.PARAMETER Specific
	A hash table containing the specific set of variables needed by this function
		Pkcs10: the Base64-encoded PKCS#10-formatted certificate signing request (CSR) to be enrolled
		SubjectDN: the requested subject distiguished name as a hash table. OU is a string array and all others are strings.
		SubjAltNames: hash table keyed by SAN type. Values are string arrays.
.NOTES
	Returns a hash table that includes the following variables:
		Result: 'Success' to indicate the non-error completion state. NOTE: this function is required.
		TransId: the identifier used to subsequently approve and/or retrieve the certificate from the CA 
		Pkcs7: a collection that includes the issued certificate and (optionally) includes all of the CA certificates in the chain
##################################################################################################>"},
            { "Submit-CsrAsRenewal",@"<##################################################################################################
.NAME
	Submit-CsrAsRenewal
.DESCRIPTION
	Submits a CSR to a CA for enrollment as a renewal of an existing certificate
.PARAMETER General
	A hash table containing the general set of variables needed by most (or all) functions (see Test-Settings)
.PARAMETER Specific
	A hash table containing the specific set of variables needed by this function. See Submit-CsrAsNew, as well as the following:
        CertId : a string that uniquely identifies the certificate issued by the CA to be renewed
	    CertPem : the raw, Base64-encoded X509 certificate to be renewed
.NOTES
	Returns a hash table that includes the same variables detailed in Submit-CsrAsNew
##################################################################################################>" },
            { "Submit-CsrAsReplacement", @"<##################################################################################################
.NAME
	Submit-CsrAsReplacement
.DESCRIPTION
	Submits a CSR to a CA for enrollment as a replacement for an existing certificate
.PARAMETER General
	A hash table containing the general set of variables needed by most (or all) functions (see Test-Settings)
.PARAMETER Specific
	A hash table containing the specific set of variables needed by this function. See Submit-CsrAsNew, as well as the following:
	    CertId : a string that uniquely identifies the certificate issued by the CA to be replaced
		CertPem : the raw, Base64-encoded X509 certificate to be replaced
.NOTES
	Returns a hash table that includes the same variables detailed in Submit-CsrAsNew
##################################################################################################>"},
            {"Approve-Request", @"<##################################################################################################
.NAME
	Approve-Request
.DESCRIPTION
	Approves a previously submitted CSR
.PARAMETER General
	A hash table containing the general set of variables needed by most (or all) functions (see Test-Settings)
.PARAMETER Specific
	A hash table containing the specific set of variables needed by this function
        TransId : a string that uniquely identifies the certificate request submitted to the CA
.NOTES
    Returns a hashtable that includes the following variables
        Result : 'Success' or 'NotUsed' to indicate the non-error completion state
##################################################################################################>"},
            { "Retrieve-Certificate", @"<##################################################################################################
.NAME
	Retrieve-Certificate
.DESCRIPTION
	Retrieves a signed certificate from the CA
.PARAMETER General
	A hash table containing the general set of variables needed by most (or all) functions (see Test-Settings)
.PARAMETER Specific
	A hash table containing the specific set of variables needed by this function
		CertId : a string that uniquely identifies the certificate issued by the CA
.NOTES
	Returns a hash table that includes the following variables:
		Result: 'Success' or 'NotUsed' to indicate the non-error completion state
		Status: 'Pending' or 'Issued' to indicate whether the certificate has been issued by the CA
		Pkcs7: a collection that includes the issued certificate and (optionally) all of the CA certificates in the chain
        DiscardPrivateKeyAndCsr : boolean that when $true tells the driver to discard stored assets that will not match the certificate being returned
##################################################################################################>"},
            { "Revoke-Certificate", @"<##################################################################################################
.NAME
	Revoke-Certificate
.DESCRIPTION
	Revokes a certificate issued by the CA
.PARAMETER General
	A hash table containing the general set of variables needed by most (or all) functions (see Test-Settings)
.PARAMETER Specific
	A hash table containing the specific set of variables needed by this function
		CertId: a string that uniquely identifies the certificate issued by the CA
		CertPem: the raw, Base64-encoded X509 certificate to be revoked
        ReasonCode : 1 (User Key Compromised), 2 (CA Key Compromised), 3 (User Changed Affiliation), 4 (Certificate Superseded), 5 (Original Use No Longer Valid)
		Comment: a comment provided by the revocation requester
.NOTES
	Returns a hashtable that includes the following variables:
		Result: 'Success' or 'NotUsed' to indicate the non-error completion state
##################################################################################################>"}
        };
        public Dictionary<string, string> GenericFunctions = new Dictionary<string, string>()
        {
            { "Get-AuthCert",@"
Function Get-AuthCert( [byte[]] $pkcs12, [System.Security.SecureString] $passwd )
{
    if ( $pkcs12 -ne $null )
    {
        return New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($pkcs12, $passwd)
    }
    else
    {
        throw ""A client certificate credential is required for the Symantec Managed PKI Service.""
    }
}
" },
            {"Decode-Error",@"
Function Decode-Error([Exception] $ex )
{
    try
    {
        $result = $ex.Response.GetResponseStream()
        $reader = New - Object System.IO.StreamReader($result)
                
        $xml = [xml]$reader.ReadToEnd()
        
        $errcode = $xml.Envelope.Body.Fault.detail.errorcode.""#text""
        $errmsg = $xml.Envelope.Body.Fault.detail.message.""#text""
        
        return $(""{0} ({1})"" -f $errmsg, $errcode)
    }
        catch # the response is either not xml or not in the expected format
    {
        return $ex.Message
    }
}"
            },
            { "Get-DateFormat", @"Function Get-DateFormat()
{
        return (Get-Date).ToUniversalTime().ToString(""yyyyMMddHHmmss"")
}" }
        };
        public Dictionary<string, string> Special = new Dictionary<string, string>()
        {
            {"Submit-CsrAsNew",@"
$pkcs7 = $Output.Envelope.Body.RequestSecurityTokenResponse.RequestVSSecurityTokenResponse.requestedVSSecurityToken.binarySecurityToken.""#text""
$certs = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection
$certs.Import( [Convert]::FromBase64String($pkcs7) )

foreach ( $cert in $certs )
{
    if ( -not $cert.Extensions.CertificateAuthority )
    {
        return @{ Result=""Success""; TransId=$cert.SerialNumber }
    }
}
throw ""No end-entity certificate was present in the response""
        " },
            { "Retrieve-Certificate", @"
        $pkcs7 = $Output.Envelope.Body.searchCertificateResponse.certificateList.certificateInformation.certificate
        $bytes = [Convert]::FromBase64String($pkcs7)

        return @{ Result=""Success"";Status=""Issued"";PKCS7=$bytes }"

            }
        };
        public class AHFunctionData
        {
            public string FunctionName;
            public string CallURL;
            public List<Dictionary<string, string>> CallHeaders;
            public string FunctionCode;
            public string FunctionDescription;
            public string RequestBody;
            public string RequestMethod;
            public string RequestType;
            public string CommandType;
            public bool Used;
            public Dictionary<string, int> CBIndex = new Dictionary<string, int>();
            public AHFunctionData()
            {

            }
        }

        public AHFunctionData AHBuildFunction(AHFunctionData AHFD)
        {
            TrustSSL = MReference.Config.SSLTrust;
            StringBuilder CommandString = new StringBuilder();
            StringBuilder CodeData = new StringBuilder();
            StringBuilder HeaderData = new StringBuilder();
            string OutputHandle;
            string CType;
            if (Special.ContainsKey(AHFD.FunctionName))
            {
                OutputHandle = Special[AHFD.FunctionName];
            }
            else
            {
                OutputHandle = "return @{ Result=\"Success\" }";
            }
            CodeData.AppendLine(AHFD.FunctionDescription);
            CodeData.AppendLine("Function "+AHFD.FunctionName+"()\r\n{");
            CodeData.AppendLine(ParamBlock);
            if (!AHFD.Used)
            {
                if (AHFD.FunctionName.Contains("Csr"))
                {
                    CodeData.AppendLine("\treturn Submit-CsrAsNew -general $General -specific $Specific");
                }
                else
                {
                    CodeData.AppendLine("\treturn @{ Result=\"NotUsed\" }");
                }
            }
            else
            {
                CodeData.AppendLine("\t$auth_cert = Get-AuthCert $General.PfxData $General.PfxPass");
                CodeData.Append("\r\n\t$Headers = @{");
                foreach (Dictionary<string,string> HeaderNameVal in AHFD.CallHeaders)
                {
                    foreach (KeyValuePair<string,string> KVPH in HeaderNameVal)
                    {
                        CodeData.Append("\"" + KVPH.Key+"\"=\"`\""+KVPH.Value+"`\"\";");
                    }
                }
                CodeData.Append("}\r\n");
                CodeData.AppendLine("\t$Body = @\"\r\n"+AHFD.RequestBody+"\r\n\"@");
                CodeData.AppendLine("\t$URL = '"+AHFD.CallURL+"'");
                CodeData.AppendLine("\t$Method = '"+AHFD.RequestMethod+"'");
                if (AHFD.RequestType == "Json")
                {
                    CType = "application/json";
                }
                else
                {
                    CType = "text/xml";
                }
                CodeData.AppendLine("\t$RequestSplat=@{\"Headers\"=$Headers;\"Body\"=$Body;\"Uri\"=$URL;\"Method\"=$Method;\"ContentType\"=\""+CType+"\"}");
                CodeData.AppendLine("\tif($General.PfxData)\r\n\t{\r\n\t\t$RequestSplat.Certificate=$auth_cert\r\n\t}");
                CodeData.AppendLine("\ttry {");
                CodeData.AppendLine("\t\t[xml]$Output = " + AHFD.CommandType+" @RequestSplat -UseBasicParsing");
                CodeData.AppendLine("\t\t"+OutputHandle);
                CodeData.AppendLine("\t} catch {");
                CodeData.AppendLine("\t\tthrow $_.Exception.Message");
                CodeData.AppendLine("\t}");
            }
            CodeData.AppendLine("}");
            AHFD.FunctionCode = CodeData.ToString();
            return AHFD;
        }

        //    <###################### THE FUNCTIONS AND CODE BELOW THIS LINE ARE NOT CALLED DIRECTLY BY VENAFI ######################>

        public AdaptableHelper()
        {

        }
    }
}
