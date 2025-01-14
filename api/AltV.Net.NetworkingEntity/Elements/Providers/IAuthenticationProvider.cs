using System;
using System.Threading.Tasks;
using AltV.Net.NetworkingEntity.Elements.Entities;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity.Elements.Providers
{
    /// <summary>
    /// The authentication provider controls which player is designated to which websocket
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Verify if the token is valid and associate the websocket with a client (player)
        /// </summary>
        /// <param name="webSocket">Websocket that received the auth event</param>
        /// <param name="token">Token received via AuthEvent</param>
        /// <param name="client">The client that matches the authentication</param>
        /// <returns></returns>
        Task<bool> Verify(ManagedWebSocket webSocket, string token, out INetworkingClient client);

        /// <summary>
        /// Returns the client that is designated to a given websocket
        /// </summary>
        /// <param name="webSocket">The websocket</param>
        /// <returns>Returns the player or null</returns>
        INetworkingClient GetClient(ManagedWebSocket webSocket);

        /// <summary>
        /// Triggers when the websocket connection is broken, is useful when the authentication depends on the websocket connection and no other data
        /// </summary>
        /// <param name="webSocket"></param>
        void OnConnectionBroken(ManagedWebSocket webSocket);

        /// <summary>
        /// Triggers when a new websocket connection is established
        /// </summary>
        /// <param name="webSocket"></param>
        void OnConnectionEstablished(ManagedWebSocket webSocket);
        
        /// <summary>
        /// Triggers when websocket processing throws a error
        /// </summary>
        /// <param name="webSocket"></param>
        /// <param name="exception"></param>
        void OnError(ManagedWebSocket webSocket, Exception exception);

        /// <summary>
        /// Triggers when client says it would be in streaming range, we can use this to make stream in / out more trustful
        /// </summary>
        /// <param name="client"></param>
        /// <param name="entity"></param>
        /// <param name="inRange">Defines if the request is for entity is in range or not</param>
        /// <returns></returns>
        bool VerifyPosition(INetworkingClient client, INetworkingEntity entity, bool inRange);
    }
}