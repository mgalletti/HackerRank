/*
Detect a cycle in a linked list. Note that the head pointer may be 'null' if the list is empty.

A Node is defined as: 
    class Node {
        int data;
        Node next;
    }
*/

boolean hasCycle(Node head) {    
    if (head == null)
        return false;
    Integer counter = 0;
    while (head.next != null)
    {
        head = head.next;
        counter++;
        if (counter > 100) 
            return true;
            
    }
    return false;
}
