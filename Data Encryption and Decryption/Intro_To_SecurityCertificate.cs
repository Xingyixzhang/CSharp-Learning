using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace SecurityCertificate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Certs in StoreLocation.LocalMachine ========");
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            foreach (var storeCert in store.Certificates)
            {
                Console.WriteLine("-------------------------------- \n" + storeCert);
            }

            Console.WriteLine("\n========== Certs in StoreLocation.CurrentUser ========");
            var store1 = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store1.Open(OpenFlags.ReadOnly);

            foreach (var storeCert in store1.Certificates)
            {
                Console.WriteLine("-------------------------------- \n" + storeCert);
            }
        }
    }
}

/*
========== Certs in StoreLocation.LocalMachine ========
--------------------------------
[Subject]
  CN=localhost

[Issuer]
  CN=localhost

[Serial Number]
  1DFBBC32ADFA55B44BA2E1B39A797EA0

[Not Before]
  2/1/2020 5:06:30 PM

[Not After]
  1/31/2025 4:00:00 PM

[Thumbprint]
  06EE3CBB1F1BFD3CED1C8B831DD01AAF8EB6E3A0


========== Certs in StoreLocation.CurrentUser ========
--------------------------------
[Subject]
  CN=FullOSTransport

[Issuer]
  CN=FullOSTransport

[Serial Number]
  5EA9CC57F5817A9B43484A7A3988D535

[Not Before]
  3/28/2020 11:53:50 AM

[Not After]
  3/16/2071 11:53:50 AM

[Thumbprint]
  EBAE12197E75043F73FE51E8E8161150AF9371CB

--------------------------------
[Subject]
  CN=ZHANG.XINGYI.1534872263, OU=USA, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Issuer]
  CN=DOD EMAIL CA-49, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Serial Number]
  1A82E1

[Not Before]
  9/30/2019 5:00:00 PM

[Not After]
  7/22/2020 4:59:59 PM

[Thumbprint]
  CA796ADEAA739AFAD7B892A7D18EB04508ABC12B

--------------------------------
[Subject]
  CN=localhost

[Issuer]
  CN=localhost

[Serial Number]
  45EE69B0FFDFD24B

[Not Before]
  3/17/2020 3:50:53 PM

[Not After]
  3/17/2021 3:50:53 PM

[Thumbprint]
  B9AE990A258A25364101BB449331E66ED933349C

--------------------------------
[Subject]
  CN=ZHANG.XINGYI.1534872263, OU=USA, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Issuer]
  CN=DOD ID CA-52, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Serial Number]
  183EE7

[Not Before]
  9/30/2019 5:00:00 PM

[Not After]
  7/22/2020 4:59:59 PM

[Thumbprint]
  9A04AAD0EC9A0D96479D671BF252CB817D866CA4

--------------------------------
[Subject]
  CN=ZHANG.XINGYI.1534872263, OU=USA, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Issuer]
  CN=DOD EMAIL CA-50, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Serial Number]
  14BB10

[Not Before]
  2/25/2020 4:00:00 PM

[Not After]
  7/22/2020 4:59:59 PM

[Thumbprint]
  954C9B4D05FCF3F8D890A5BD92E5AC2E6422870D

--------------------------------
[Subject]
  CN=ZHANG.XINGYI.1534872263, OU=USA, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Issuer]
  CN=DOD EMAIL CA-50, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Serial Number]
  0EA589

[Not Before]
  9/30/2019 5:00:00 PM

[Not After]
  7/22/2020 4:59:59 PM

[Thumbprint]
  7A4C9EF7ED680CEB596496C8AA1D45AE2E9B6965

--------------------------------
[Subject]
  CN=ZHANG.XINGYI.1534872263, OU=USA, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Issuer]
  CN=DOD EMAIL CA-49, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Serial Number]
  20AAFD

[Not Before]
  2/25/2020 4:00:00 PM

[Not After]
  7/22/2020 4:59:59 PM

[Thumbprint]
  733D4DAED08E31CA1975774C4E3BC468763495C0

--------------------------------
[Subject]
  CN=ZHANG.XINGYI.1534872263, OU=USA, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Issuer]
  CN=DOD ID CA-50, OU=PKI, OU=DoD, O=U.S. Government, C=US

[Serial Number]
  140A6E

[Not Before]
  2/25/2020 4:00:00 PM

[Not After]
  7/22/2020 4:59:59 PM

[Thumbprint]
  5ED3D433A95D1B506AC10120677E338A123FA0D5

--------------------------------
[Subject]
  CN=1811a09d-e4c9-44d0-ad0e-2cbf570fb79c

[Issuer]
  DC=net + DC=windows + CN=MS-Organization-Access + OU=82dbaca4-3e81-46ca-9c73-0950c1eaca97

[Serial Number]
  130306190B5092984030700C3B3483A0

[Not Before]
  4/20/2020 12:55:38 PM

[Not After]
  4/20/2030 1:25:38 PM

[Thumbprint]
  41D46384BF61F31F60BA70049627DB89871903EE

Press any key to continue . . .
 */
