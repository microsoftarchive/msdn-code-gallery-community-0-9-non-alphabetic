# .Net Implementation of a Priority Queue (aka Heap)
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
## Topics
- IEnumerable
- Data Structures
- PriorityQueue
## Updated
- 06/16/2012
## Description

<p>The code represents an F# .Net implementation of a Priority Queue; implemented using a heap data structure. Conceptually once can think of a heap as a balanced binary tree. The tree will have a root, and each node can have up to two children; a left and
 a right child. The keys in such a binary tree are said to be in heap order, such that any element is at least as large as its parent element.</p>
<p><span style="font-family:Consolas"><span style="font-size:x-small"><em>For every element v, at a node i, the element w at i&rsquo;s parent satisfies</em> key(w)&le;key(v)</span></span></p>
<p>The heap is maintained as an array, indexed by i=1&hellip;N, such that for any node i, the nodes at positions
<span style="font-family:Consolas">leftChild(i)=2i</span> and <span style="font-family:Consolas">
rightChild(i)=2i&#43;1</span>, and the parent of the node is at position <span style="font-family:Consolas">
parent(i)=(1/2)</span>.</p>
<p>The idea behind a Priority Queue is that finding the element with the lowest key is easy,
<span style="font-family:Consolas">O(<em>1</em>)</span> time, as it is always the root. When adding a new element it is always added to the end of the list. The heap is then fixed by recursively checking the new element with its parent, and swapping their positions
 in the list until the heap condition is satisfied. This operation takes <span style="font-family:Consolas">
O(log <em>n</em>)</span> time.</p>
<p>Within .Net we implemented a Priority Queue using a <span style="font-family:Consolas">
List&lt;KeyValuePair&lt;'TKey, 'TValue&gt;&gt;</span>.</p>
<p>The basic operations supported on the Priority Queue will be:</p>
<table border="1" cellspacing="0" cellpadding="1" width="491">
<tbody>
<tr>
<td width="142" valign="top"><em>Enqueue</em></td>
<td width="347" valign="top">Adds an item to the Queue</td>
</tr>
<tr>
<td width="142" valign="top"><em>Dequeue</em></td>
<td width="347" valign="top">Removes the root element; that with the lowest key</td>
</tr>
<tr>
<td width="142" valign="top"><em>Peek</em></td>
<td width="347" valign="top">Queries the root element</td>
</tr>
<tr>
<td width="142" valign="top"><em>IndexOf</em></td>
<td width="347" valign="top">Returns the index of a given key value pair</td>
</tr>
<tr>
<td width="142" valign="top"><em>RemoveAt</em></td>
<td width="347" valign="top">Removes the element at the specified index value</td>
</tr>
<tr>
<td width="142" valign="top"><em>ContainsKey</em></td>
<td width="347" valign="top">Determines whether the Queue contains a specific key value</td>
</tr>
<tr>
<td width="142" valign="top"><em>GetValues</em></td>
<td width="347" valign="top">Gets the values for a specified key</td>
</tr>
<tr>
<td width="142" valign="top"><em>ChangeKey</em></td>
<td width="347" valign="top">Changes a specific key value</td>
</tr>
<tr>
<td width="142" valign="top"><em>RemoveKey</em></td>
<td width="347" valign="top">Removes the element with the specific key value</td>
</tr>
<tr>
<td width="142" valign="top"><em>Item</em></td>
<td width="347" valign="top">An indexer based on the index values</td>
</tr>
<tr>
<td width="142" valign="top"><em>Merge</em></td>
<td width="347" valign="top">Merges an Enumerable with the Queue</td>
</tr>
</tbody>
</table>
<p>A&nbsp;quick word is warranted about the implementation. The Key operations shown above rely on a second data structure; a
<span style="font-family:Consolas">Dictionary&lt;'TKey, int&gt;</span>. This secondary data structure maintains a reference of the index within the list for each key. This positional structure uses a list off index values associated with each key, allowing
 items with the same key value to be added to the queue.</p>
<p>Specifics of the code can also be found on my blog at:</p>
<p><a href="http://blogs.msdn.com/b/carlnol/archive/2012/05/03/net-implementation-of-a-priority-queue-aka-heap.aspx">http://blogs.msdn.com/b/carlnol/archive/2012/05/03/net-implementation-of-a-priority-queue-aka-heap.aspx</a></p>
<p>Version History:</p>
<p>1. Base Version</p>
<p>2. Implemented Merge operations</p>
<p>3. Allowed same key value</p>
