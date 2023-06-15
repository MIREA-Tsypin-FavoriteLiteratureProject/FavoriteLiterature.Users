namespace Users.Domain.Authentication.Responses.Commands;

public class AuthenticationResponse
{
    public string TypeToken { get; set; }

    public string AccessToken { get; set; }

    public int Lifetime { get; set; }

    public AuthenticationResponse(string typeToken, string accessToken, int lifetime)
    {
        TypeToken = typeToken;
        AccessToken = accessToken;
        Lifetime = lifetime;
    }
}