namespace Admin.Startup.Features.Identity
{
    using System.Threading.Tasks;
    using Models;
    using Refit;

    public interface IIdentityService
    {
        [Post("/api/v1/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
