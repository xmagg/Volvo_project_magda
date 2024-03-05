using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using NewsPlatform2.Models;
using NewsPlatform2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace NewsPlatform2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //await CreateDataUser();
            //await CreateDataNews();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            object value = builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static async Task CreateDataUser()
        {
            using (var context = new NewsDbContext())
            {
                context.Database.EnsureCreated();

                var user1 = new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "admin",
                    Password = "admin",
                    Level = 1
                };
                var u1 = await context.Users.AddAsync(user1); 
                var result = await context.SaveChangesAsync();
            }
        }

        private static async Task CreateDataNews()
        {
            using (var context = new NewsDbContext())
            {
                context.Database.EnsureCreated();

                var news1 = new News()
                {
                    Id = Guid.NewGuid(),
                    Title = "Are Bayern Munich heading towards their worst season for over a decade?",
                    Content = "Yet Bayern Munich find themselves on unfamiliar ground, 10 points adrift of Bundesliga leaders Bayer Leverkusen, as they chase a 12th consecutive German title. Outgoing manager Thomas Tuchel has reportedly singled out dissenting stars in what appears an unhappy dressing room and a second-leg rescue act will be required to advance past Lazio in the last 16 of the Champions League on Tuesday. The Bavarians also began the campaign with a German Super Cup defeat and were embarrassingly knocked out of the German Cup by third-tier Saarbrucken in November. And, in February, their Germany midfielder Leon Goretzka described the current campaign as being like \"a horror movie that won't end\". So are Germany's biggest club heading for their worst season for over a decade or is this a blip they can recover from? The statistics suggest that Bayern's domestic invincibility is about to come to an end. No team has ever made up a 10-point deficit to claim the German league title and it is a gap that, if anything, only appears to be widening, with Bayern having won only one of their past four matches. Bayern have averaged almost one loss in every four games (11 of 46) under Tuchel and recently slipped to defeat in three successive matches in all competitions for the first time in almost nine years. Tuchel's record of losing 24% of his matches as Bayern boss is also the worst percentage since Soren Lerby was at the helm (1991-92), with the Dane seeing his side defeated in 41% of his fixtures in charge.Former Chelsea and Borussia Dortmund boss Tuchel also has the lowest win percentage (63%) since Louis van Gaal (2009-11) presided over team affairs and managed 61%. Under the 50-year-old, Bayern have also lost five and won one just once in knockout matches - an ominous sign before Tuesday's second leg with Lazio.",
                };
                var n1 = await context.Newss.AddAsync(news1);
                var result = await context.SaveChangesAsync();
            }
        }
    }
}