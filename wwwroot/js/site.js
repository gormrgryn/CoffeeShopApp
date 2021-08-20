class Node {
    constructor(elem) {
        this.elem = elem
        this.next = null
        this.prev = null
    }
}
class LinkedList {
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
    find(elem) {
        let currentNode = this.head
        while(currentNode) {
            if (currentNode.elem == elem) return currentNode
            currentNode = currentNode.next
        }
    }
}

const list = new LinkedList()

document.querySelectorAll('.drink').forEach(i => {
    list.add(i)
    i.addEventListener('focus', () => {
        i.classList.toggle('focused')
    })
    i.addEventListener('blur', () => {
        i.classList.toggle('focused')
    })
    const leftArrow = i.childNodes[3].childNodes[1]
    const rightArrow = i.childNodes[3].childNodes[3]
    leftArrow.addEventListener('click', () => {
        let node = list.find(i)
        node.elem.blur()
        if (node.prev) {
            node.prev.elem.focus()
        } else {
            list.tail.elem.focus()
        }
    })
    rightArrow.addEventListener('click', () => {
        let node = list.find(i)
        node.elem.blur()
        if (node.next) {
            node.next.elem.focus()
        } else {
            list.head.elem.focus()
        }
    })
})