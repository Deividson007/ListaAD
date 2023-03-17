using ConsoleAD;
using System.DirectoryServices.AccountManagement;

var myDomainUsers = new List<ADUser>();

using (var ctx = new PrincipalContext(ContextType.Domain, "172.16.10.104"))
{
    var userPrinciple = new UserPrincipal(ctx);

    using (var search = new PrincipalSearcher(userPrinciple))
    {
        foreach (UserPrincipal domainUser in search.FindAll().OrderBy(u => u.DisplayName))
        {
            var adUser = new ADUser()
            {
                Description = domainUser.Description,
                DisplayName = domainUser.DisplayName,
                DistinguishedName = domainUser.DistinguishedName,
                EmailAddress = domainUser.EmailAddress,
                Name = domainUser.Name,
                EmployeeId = domainUser.EmployeeId,
                GivenName = domainUser.GivenName,
                MiddleName = domainUser.MiddleName,
                Surname = domainUser.Surname,
                SamAccountName = domainUser.SamAccountName
            };
            myDomainUsers.Add(adUser);
            Console.WriteLine($"{adUser.Name} - {adUser.EmployeeId}");
        } //foreach
    } //using
} //using



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
