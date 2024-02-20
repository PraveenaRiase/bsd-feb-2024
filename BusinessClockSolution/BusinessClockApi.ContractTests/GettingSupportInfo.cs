using Alba;

namespace BusinessClockApi.ContractTests;

public class GettingSupportInfo

{

    [Fact]

    public async Task WhenWeAreOpen()

    {

        var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>

        {

            api.Get.Url("/support-info");

            api.StatusCodeShouldBeOk();

        });
        var expected = new SupportInfoResponse("Graham", "555-1212");

        var actualResponse = response.ReadAsJson<SupportInfoResponse>();

        Assert.Equal(expected, actualResponse);

    }
    [Fact]
    public async Task WhenWeAreClosed()
    {
        var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/support-info");
            api.StatusCodeShouldBeOk();
        });

        var expected = new SupportInfoResponse("TechSupportPros", "800-STUF-BROKE");

        var actualResponse = response.ReadAsJson<SupportInfoResponse>();

        Assert.Equal(expected, actualResponse);
    }

}



