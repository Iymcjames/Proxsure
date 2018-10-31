import { UserManagerSettings } from 'oidc-client';

export function getAuthClientSettings(): UserManagerSettings {
  return {
    authority: 'http://localhost:5000/',
    client_id: 'Proxsure_SPA',
    redirect_uri: 'http://localhost:4200/dashboard',
    post_logout_redirect_uri: 'http://localhost:4200/',
    response_type: 'id_token token',
    scope: 'openid profile Proxsure_API1',
    filterProtocolClaims: true,
    loadUserInfo: true
  };
}
