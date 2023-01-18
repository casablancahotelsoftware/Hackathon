using System;
using System.Threading.Tasks;
using VitualReception.Domain.Model;

namespace VirtualReception.Server.Hubs
{
    /// <summary>
    /// Methods that can be invoked on the <see cref="ChatHub"/> instance.
    /// </summary>
    public interface IChatHub
    {
        /// <summary>
        /// Sends a <see cref="Message"/> to clients.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> instance.</param>
        public Task ReceiveMessage(Message message);

        /// <summary>
        /// Clients can send <see cref="Message"/> instances over this method. 
        /// </summary>
        /// <param name="chatId">The unique identifier of a <see cref="Chat"/> instance.</param>
        /// <param name="message">The <see cref="Message"/> instance.</param>
        public Task WriteMessage(Guid chatId, Message message);
    }
}
