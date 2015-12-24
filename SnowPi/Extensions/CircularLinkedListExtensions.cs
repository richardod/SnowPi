using System.Collections.Generic;

namespace SnowPi.Extensions
{
    /// <summary>
    ///     Makes a linked list act circular
    /// </summary>
    public static class CircularLinkedListExtensions
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }
    }
}