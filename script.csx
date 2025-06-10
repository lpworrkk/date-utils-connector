public class Script : ScriptBase
{
    private readonly List<List<string>> entries = new List<List<string>>();
    private string currentEntry = "";
    private bool insideQuotation = false;

    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        if (this.Context.OperationId == "isLastDateOfMonth")
        {
	    return await this.isDateLastDayOfTheMonth().ConfigureAwait(false);
	}

        if (this.Context.OperationId == "isTodayLastDateOfMonth")
        {
	    return await this.isTodayLastDateOfMonth().ConfigureAwait(false);
	}

        // Handle an invalid operation ID
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        response.Content = CreateJsonContent($"Unknown operation ID '{this.Context.OperationId}'");
        return response;
    }

    private async Task<HttpResponseMessage> isDateLastDayOfTheMonth()
    {
        HttpResponseMessage response;

        var contentAsString = await this.Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false);

        // Parse as JSON object
        var contentAsJson = JObject.Parse(contentAsString);

        // Get the value of Date (parameter passed)
        var dateIn = (string)contentAsJson["Date"];
        var isLastDay = false;

        var parsedDate = DateTime.Parse( dateIn );
        DateTime tomorrow = parsedDate.AddDays(1);
		if ( tomorrow.Day==1 ) {
            isLastDay = true;
		}

        JObject output = new JObject
        {
            ["inputDate"] = dateIn,
            ["islastday"] = isLastDay,
        };

        response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = CreateJsonContent(output.ToString());
        return response;
    }

    private async Task<HttpResponseMessage> isTodayLastDateOfMonth()
    {
        HttpResponseMessage response;

        var isLastDay = false;
	if ( (DateTime.Now.AddDays(1)).Day==1 ) {
            isLastDay = true;
	}

        JObject output = new JObject
        {
            ["isTodayLastDayOfMonth"] = isLastDay,
        };

        response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = CreateJsonContent(output.ToString());
        return response;
    }


}
