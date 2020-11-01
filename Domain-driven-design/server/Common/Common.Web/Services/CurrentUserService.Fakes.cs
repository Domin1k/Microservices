namespace PetFoodShop.Web.Services
{
    using System;
    using Application.Contracts;
    using FakeItEasy;

    public class CurrentUserServiceFakes
    {
        public static int CompanyUserFakeId = 1;
        public static Guid CompanyUserFakeApplicationId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
        public static string CompanyUserFakeEmailAddress = "domin1k@mysite.com";

        public static ICurrentUserService FakeCurrentUserService
        {
            get
            {
                var currentUserService = A.Fake<ICurrentUserService>();

                A
                    .CallTo(() => currentUserService.UserId)
                    .Returns(CompanyUserFakeApplicationId);

                A
                    .CallTo(() => currentUserService.Email)
                    .Returns(CompanyUserFakeEmailAddress);

                return currentUserService;
            }
        }
    }
}
