var builder = DistributedApplication.CreateBuilder(args);

var thoemusBikeDb = builder.AddPostgres("postgres")
    .AddDatabase("ThoemusBikePostgres");

var idsrv = builder.AddProject<Projects.ThoemusBike_Identity>("thoemusbike-identity");
var idEndpoint = idsrv.GetEndpoint("https");

var api = builder.AddProject<Projects.ThoemusBike_Api>("thoemusbike-api")
    .WithEnvironment("Auth__Authority", idEndpoint)
    .WithReference(thoemusBikeDb);

var smtp = builder.AddSmtp4Dev("SmtpUri");

builder.AddProject<Projects.ThoemusBike_WebApp>("thoemusbike-webapp")
    .WithEnvironment("Auth__Authority", idEndpoint)
    .WithReference(api) // alternative to above
    .WithReference(smtp);

builder.Build().Run();
