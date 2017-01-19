<Query Kind="Expression">
  <Connection>
    <ID>d6c3b86b-2cc5-4fd2-a5eb-af004570f269</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//  craete a list of employees and their related customers they support
//Aggregate method are executed against collections
//the many end of aq navigation property is considered a collection
//when using a subquery with the collection source being a navigation
//property, only the records frm the navigation collection(Customer) that 
// that belong to the navigation parent(Employee) are considered
from x in Employees
where x.SupportRepIdCustomers.Count()>0
select new{
Title = x.Title,
Name =x.FirstName +" "+x.LastName,
Phone = x.Phone,
Customers = from y in x.SupportRepIdCustomers
            orderby y.LastName, y.FirstName
            select new{
			   Name = y.LastName+ ", " +y.FirstName,
			   Company = y.Company,
			   Phone = y.Phone,
			   Email = y.Email
			}
}