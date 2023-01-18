using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using VitualReception.Domain.Model;

namespace VirtualReception.Server.Hubs
{
    /// <summary>
    /// The SignalR Hubs API enables connected clients to call methods on the server. 
    /// The server defines methods that are called from the client and the client defines methods that are called from the server. 
    /// SignalR takes care of everything required to make real-time client-to-server and server-to-client communication possible.
    /// </summary>
    public class ChatHub : Hub<IChatHub>
    {
        #region dependencies

        private readonly IChatRepository _chatRepository;

        #endregion

        #region ctors

        public ChatHub(IChatRepository groupRepository)
        {
            _chatRepository = groupRepository;
        }

        #endregion

        /// <summary>
        /// Invoked when a client writes a message. Brodcasts this message to all currently connected clients of this SignalR group.
        /// </summary>
        /// <param name="chatId">The unique identifier of a <see cref="Chat"/> instance.</param>
        /// <param name="message">The published message.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task WriteMessage(Guid chatId, Message message)
        {
            var chat = await _chatRepository.FindAsync(chatId);
            if (chat == null)
            { throw new InvalidOperationException(); }

            chat.Messages.Add(message);

            await Clients.Group(chatId.ToString()).ReceiveMessage(message);
        }

        #region overrides

        /// <summary>
        /// Connects a client and put it into the <see cref="Chat"/> instance.
        /// </summary>
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();

            var chatId = GetChatId(httpContext);

            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());

            await base.OnConnectedAsync();
        }

        /// <summary>
        /// Disconnects a client and removes it from the <see cref="Chat"/> instance.
        /// </summary>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = Context.GetHttpContext();

            var chatId = GetChatId(httpContext);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());

            await base.OnDisconnectedAsync(exception);
        }

        #endregion

        #region helpers

        // Gets the unique identifier of a chat from query parameter. 
        private static Guid GetChatId(HttpContext context)
        {
            if (context.Request.Query.TryGetValue("chatId", out var chatId))
            {
                return Guid.Parse(chatId);
            }
            throw new InvalidOperationException("Cannot connect without chatId");
        }

        #endregion
    }
}
