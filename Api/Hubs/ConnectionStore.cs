using System.Collections.Generic;

namespace Api.Hubs
{
    public class ConnectionStore
    {
        private Dictionary<string, string> _connections;

        public ConnectionStore()
        {
            _connections = new Dictionary<string, string>();
        }

        public void Add(string key, string connectionId)
        {
            string connectionIdFromStore = GetConnectionId(key);

            if (!string.IsNullOrEmpty(connectionIdFromStore))
            {
                if (connectionIdFromStore != connectionId)
                {
                    _connections[key] = connectionId;
                }
            }
            else
            {
                _connections.Add(key, connectionId);
            }
        }

        public void Remove(string key)
        {
            string connectionIdFromStore = GetConnectionId(key);

            if (!string.IsNullOrEmpty(connectionIdFromStore))
            {
                _connections.Remove(key);
            }
        }

        public string GetConnectionId(string key)
        {
            bool isSuccess = _connections.TryGetValue(key, out string connectionIdFromStore);

            if (isSuccess)
            {
                return connectionIdFromStore;
            }

            return string.Empty;
        }
    }
}