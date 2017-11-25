using System;
using System.Collections.Generic;

namespace HareEngine {

    public class Debug {

        public enum MessageType {
            Warning, Error, Log
        }

        public class Message {

            public string Text;
            public MessageType Type;

            public Message(MessageType type, string text) {
                Type = type;
                Text = text;
            }

        }

        public delegate void DebugListener(MessageType type, string msg);

        private static List<DebugListener> listeners = new List<DebugListener>();

        public static void Register(DebugListener listener) {
            listeners.Add(listener);
        }

        public static bool Unregister(DebugListener listener) {
            return listeners.Remove(listener);
        }

        public static void Broadcast(MessageType type, string msg) {
            foreach (DebugListener dl in listeners) {
                dl(type, msg);
            }
        }

        public static void Exception(Exception e) {
            Error(e.Message + "\n" + e.TargetSite + "\n" + e.StackTrace);
        }

        public static void Warning(string msg) {
            Broadcast(MessageType.Warning, msg);
        }

        public static void Error(string msg) {
            Broadcast(MessageType.Error, msg);
        }

        public static void Log(string msg) {
            Broadcast(MessageType.Log, msg);
        }

        public static void Warning(object msg) {
            Broadcast(MessageType.Warning, msg.ToString());
        }

        public static void Error(object msg) {
            Broadcast(MessageType.Error, msg.ToString());
        }

        public static void Log(object msg) {
            Broadcast(MessageType.Log, msg.ToString());
        }

    }

}
