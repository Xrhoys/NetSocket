using System;
using System.Collections;

namespace Communication
{
    [Serializable]
    public class Channel
    {
        private static ArrayList _channel_list = new ArrayList();

        private ArrayList _connected_user;
        private static int _id_increment = 0;
        private int _id;
        public int id
        {
            get { return _id; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        private ArrayList _messageList;

        public Channel(string name, string description)
        {
            _id = ++_id_increment;
            _name = name;
            _description = description;
            _messageList = new ArrayList();
            _connected_user = new ArrayList();
            _channel_list.Add(this);
        }
        public void Add(Message message)
        {
            this._messageList.Add(message);
        }

        public void Delete(Message message)
        {
            if (_messageList.Contains(message))
            {
                _messageList.Remove(message);
            }
        }

        public void AddUser(int user)
        {
            if (user != 0)
            {
                _connected_user.Add(user);
            }
        }

        public void RemoveUser(int user)
        {
            if (_connected_user.Contains(user))
            {
                _connected_user.Remove(user);
            }
        }

        public bool ContainsUser(User user)
        {
            if(_connected_user.Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ArrayList GetUserList()
        {
            return _connected_user;
        }

        public ArrayList GetMessageList()
        {
            return _messageList;
        }

        public static Channel GetChannelById(int id)
        {
            foreach (Channel ch in _channel_list)
            {
                if (ch._id == id)
                {
                    return ch;
                }
            }
            return null;
        }

        ~Channel()
        {
            if (_channel_list.Contains(this))
            {
                this._messageList.Clear();
                _channel_list.Remove(this);
            }
            else
            {
                Console.WriteLine("Channel not found.");
            }
        }
    }

    public class Chat : Channel
    {
        private ArrayList message_log;
        public Chat(string name, string description) : base(name, description)
        {
            this.message_log = new ArrayList();
        }
    }
}
