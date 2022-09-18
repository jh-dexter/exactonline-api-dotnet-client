using OAuth2.Configuration;

namespace OAuth2.Client;

/// <summary>
/// Defines API for doing user authentication using certain third-party service.
/// </summary>
/// <remarks>
/// Standard flow is:
/// - client is used to generate login link (<see cref="GetLoginLinkUriAsync"/>)
/// - hosting app renders page with generated login link
/// - user clicks login link - this leads to redirect to third-party service site
/// - user authenticates and allows app access their basic information
/// - third-party service redirects user to hosting app
/// - hosting app reads user information using <see cref="GetUserInfoAsync"/> method
/// </remarks>
internal interface IClient
{
	/// <summary>
	/// Friendly name of provider (third-party authentication service). 
	/// Defined by client implementation developer and supposed to be unique.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// Returns URI of service which should be called in order to start authentication process. 
	/// You should use this URI when rendering login link.
	/// </summary>
	Task<string> GetLoginLinkUriAsync(string? state = null, CancellationToken cancellationToken = default);

	/// <summary>
	/// State which was posted as additional parameter 
	/// to service and then received along with main answer.
	/// </summary>
	string? State { get; }

	/// <summary>
	/// Client configuration object.
	/// </summary>
	IClientConfiguration Configuration { get; }
}
