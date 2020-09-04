# clean-architecture-template

Template based on [Clean Architecture](http://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).

### - Core (net standard) - Business logic (only known by the Core)
Main responsibilities:
1. Definition of domain entities.
1. Definition of contracts (interfaces) for repositories, services (mail delivery service, etc), use cases (including OutputPorts).
1. Implementation of use cases. They may require interacting with wrappers, third-party applications, etc.

------------


### - Infrastructure (net standard) - Does not know business logic
Main responsibilities:
1. Implement corresponding contracts (interfaces) defined by the Core (repositories, mail delivery service, etc)

------------


To make use of the business logic (Core), the OutputPorts contracts (interfaces) defined by the Core must be implemented.

------------


As an example, an API was created

### - Api (net core) - Interface through which third-party or proprietary applications interact with the Core
Main responsibilities:
1. Decision of which implementations to use of the contracts defined in the Core (dependency injection). For example, for the IFooRepository contract use the implementation FooSqlServerDapperRepository.
1. Implement contracts (interfaces) OutputPorts defined by the Core. Here it will be implemented what is considered necessary after a Success or an Error of the execution of a use case.

------------


The decision to use net standard, and not net core or net framework, as target framework in Infrastructure and Core, was to have the possibility of including such libraries in both asp net core and asp net projects (WebForms, WebServices SOAP, WCF, ASP NET MVC, etc).

Net standard support:
<table>
<thead>
<tr>
<th> .NET Standard </th>
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.0.md" data-linktype="external"> 1.0 </a> </ th >
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.1.md" data-linktype="external"> 1.1 </a> </ th >
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.2.md" data-linktype="external"> 1.2 </a> </ th >
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.3.md" data-linktype="external"> 1.3 </a> </ th >
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.4.md" data-linktype="external"> 1.4 </a> </ th >
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.5.md" data-linktype="external"> 1.5 </a> </ th >
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.6.md" data-linktype="external"> 1.6 </a> </ th >
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md" data-linktype="external"> 2.0 </a> </ th >
<th> <a href="https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.1.md" data-linktype="external"> 2.1 </a> </ th >
</tr>
</thead>
<tbody>
<tr>
<td> .NET Core </td>
<td> 1.0 </td>
<td> 1.0 </td>
<td> 1.0 </td>
<td> 1.0 </td>
<td> 1.0 </td>
<td> 1.0 </td>
<td> 1.0 </td>
<td> 2.0 </td>
<td> 3.0 </td>
</tr>
<tr>
<td> .NET Framework </td>
<td> 4.5 </td>
<td> 4.5 </td>
<td> 4.5.1 </td>
<td> 4.6 </td>
<td> 4.6.1 </td>
<td> 4.6.1 </td>
<td> 4.6.1 </td>
<td> 4.6.1 </td>
<td> N / A </td>
</tr>
</tbody>
</table>
