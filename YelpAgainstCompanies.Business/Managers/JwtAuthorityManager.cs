namespace YelpAgainstCompanies.Business.Managers;

public class JwtAuthorityManager : IJwtAuthorityManager
{
    private readonly ConcurrentDictionary<string, RefreshToken> _usersRefreshTokens;
    private readonly JwtTokenConfiguration _jwtTokenConfiguration;
    private readonly byte[] _secret;

    public JwtAuthorityManager(JwtTokenConfiguration jwtTokenConfiguration)
    {
        _jwtTokenConfiguration = jwtTokenConfiguration;
        _usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
        _secret = Encoding.ASCII.GetBytes(jwtTokenConfiguration.Secret);
    }

    public JwtAuthorityResult GenerateTokens(string userName, Claim[] claims, DateTime currentTime)
    {
        var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
        var jwtToken = new JwtSecurityToken(
            _jwtTokenConfiguration.Issuer,
            shouldAddAudienceClaim ? _jwtTokenConfiguration.Audience : string.Empty,
            claims,
            expires: currentTime.AddMinutes(_jwtTokenConfiguration.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature)
            );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        var refreshToken = new RefreshToken
        {
            UserName = userName,
            TokenString = GenerateRefreshTokenString(), //TODO Write this
            ExpireAt = currentTime.AddMinutes(_jwtTokenConfiguration.RefreshTokenExpiration)
        };

        _usersRefreshTokens.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);

        return new JwtAuthorityResult
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    private static string GenerateRefreshTokenString()
    {
        var randomNumber = new byte[32];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}
