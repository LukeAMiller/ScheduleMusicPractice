# ScheduleMusicPractice
Support for ASP.NET Core Identity was added to your project
- The code for adding Identity to your project was generated under Areas/Identity.

Configuration of the Identity related services can be found in the Areas/Identity/IdentityHostingStartup.cs file.


The generated UI requires support for static files. To add static files to your app:
1. Call app.UseStaticFiles() from your Configure method

To use ASP.NET Core Identity you also need to enable authentication. To authentication to your app:
1. Call app.UseAuthentication() from your Configure method (after static files)

The generated UI requires MVC. To add MVC to your app:
1. Call services.AddMvc() from your ConfigureServices method
2. Call app.UseRouting() at the top your Configure method, and UseEndpoints() after authentication:
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapRazorPages();
    });

Apps that use ASP.NET Core Identity should also use HTTPS. To enable HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.

The email authentication is off and this app will not communicate with your email or phone in any way.
Also, This app is only run locally and is not set  up to function on the WWW.
Some functionality such as edit or delete has not been delete from the code and is still accessible through the URL but there are no 
buttons or links to certain functions.
