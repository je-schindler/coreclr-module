using AltV.Net.NetworkingEntity.Elements.Factories;
using net.vieapps.Components.WebSockets;

//TODO: move proto file to Client folder to share same file

//TODO: cache current entities byte array to send to all clients when one connects maybe
//TODO: the byte array would obviously need to be updated on data changes not sure if that would be faster

//TODO: add option to calculate positions serverside and send entities to client
namespace AltV.Net.NetworkingEntity
{
    public class Server
    {
        public readonly IStreamingHandler StreamingHandler;

        public Server(string ip, int port, IAuthenticationProviderFactory authenticationProviderFactory, IEntityStreamer streamer,
            IStreamingHandlerFactory factory)
        {
            var webSocket = new WebSocket();
            var authenticationProvider = authenticationProviderFactory.Create(ip, port, webSocket);
            var streamingHandler = factory.Create(authenticationProvider);
            StreamingHandler = streamingHandler;
            webSocket.OnMessageReceived = streamingHandler.OnMessage;
            webSocket.OnError = authenticationProvider.OnError;
            webSocket.OnConnectionEstablished = authenticationProvider.OnConnectionEstablished;
            webSocket.OnConnectionBroken = authenticationProvider.OnConnectionBroken;
            webSocket.StartListen(port);
        }
    }
}