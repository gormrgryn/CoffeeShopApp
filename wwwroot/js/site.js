class Node {
    constructor(elem) {
        this.elem = elem
        this.next = null
        this.prev = null
    }
}
class DoublyLinkedList {
    constructor() {
        this.length = 0
        this.head = null
        this.tail = null
    }
    add(elem) {
        let node = new Node(elem)
        if (this.head === null) {
            this.head = node
        } else {
            let currentNode = this.head
            while(currentNode.next) {
                currentNode = currentNode.next
            }
            currentNode.next = node
            node.prev = currentNode
            this.tail = node
        }
        this.length++
    }
    findNodeByElem(elem) {
        let currentNode = this.head
        while(currentNode) {
            if (currentNode.elem == elem) return currentNode
            currentNode = currentNode.next
        }
    }
}

const list = new DoublyLinkedList()

const toggleFocus = (i) => i.classList.toggle('focused')
const swipe = (i, right) => {
    let node = list.findNodeByElem(i)
    let dir = right ? 'next' : 'prev'
    let end = right ? 'head' : 'tail'
    let swipeNode = node[dir] || list[end]
    swipeNode.elem.focus()
}

document.querySelectorAll('.drink').forEach(i => {
    list.add(i)
    i.addEventListener('focus', () => toggleFocus(i))
    i.addEventListener('blur', () => toggleFocus(i))

    i.querySelector('.arrow-left').addEventListener('click', () => swipe(i, false))
    i.querySelector('.arrow-right').addEventListener('click', () => swipe(i, true))
})

document.querySelectorAll('.notification').forEach(i => {
    i.querySelector('.cross').addEventListener('click', () => {
        i.classList.toggle('notification-invisible')
    })
})