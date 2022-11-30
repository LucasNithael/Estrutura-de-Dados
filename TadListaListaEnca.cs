/*
- isFirst: Verifica se o parâmetro é o primeiro
- isLast: Verifica se o parâmetro é o último
- First: Retorna o primeiro elemento da lista
- Last: Retorna o último elemento da lista
- Before: Retorna o anterior do parâmetro (se primeiro retorna null)
- After: Retorna o sucessor do parâmetro (se último retorna null)
- replaceElement: Subescreve o elemento n por o 
- swapElements: Troca o elemento n de lugar com elemento o
- insertBefore: Insere antes do parâmetro o deslocando para abrir caminho
- insertAfter: Insere depois do parâmetro
- insertFirst: Insere no começo da lista
- insertLast: Insere no final da lista
- Remove: Remove o parâmetro
- Size: Retorna quantidade elementos da lista
- isEmpty: Verifica se há elementos na lista
*/

using System;

class Program{
  public static void Main(){
    try{
      Node a, b, c, d, e;
      List l = new List();
      a = l.insertFirst(1);
      b = l.insertFirst(2);
      c = l.insertFirst(3);
      //d = l.insertLast(4);
      //e = l.insertLast(5);

      Console.WriteLine("------------------------------");
      //Console.WriteLine("isFirst: "+l.isFirst(a));
      //Console.WriteLine("isLast: "+l.isLast(a));
      //Console.WriteLine("First: "+l.First().GetElement());
      //Console.WriteLine("Last: "+l.Last().GetElement());
      //Console.WriteLine("Before: "+l.Before(a).GetElement());
      //Console.WriteLine("After: "+l.After(c).GetElement());
      //Console.WriteLine("replaceElement: "+l.replaceElement(a, 4));
      //l.swapElements(a, c);
      //l.insertBefore(c, 5);
      //l.insertAfter(a, 100);
      //Console.WriteLine("Remove: "+l.Remove(a));
      Console.WriteLine("Size:"+l.Size());
      Console.WriteLine("------------------------------");
      
      Console.WriteLine("\nInício para o Fim:");
      l.Ver_Lista_i();
      Console.WriteLine("\nFim para o Início:");
      l.Ver_Lista_f();
    }
    catch(ListVazia){
      Console.WriteLine("Lista Vazia");
    }
  }
}

/*---------CLASSE DA LISTA----------*/
class List{
  private Node i = new Node(null); 
  private Node f = new Node(null);
  private int size;
  public List(){
    i.SetNext(f);
    f.SetPrev(i);
  }
  public Boolean isFirst(Node o){
    if(isEmpty())
      throw new ListVazia("Lista Vaiza");
    return i.GetNext()==o;
  }
  public Boolean isLast(Node o){
    if(isEmpty())
      throw new ListVazia("Lista Vaiza");
    return f.GetPrev()==o;
  }
  public Node First(){
    if(isEmpty())
      throw new ListVazia("Lista Vaiza");
    return i.GetNext();
  }
  public Node Last(){
    if(isEmpty())
      throw new ListVazia("Lista Vaiza");
    return f.GetPrev();
  }
  public Node Before(Node n){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    return n.GetPrev();
  }
  public Node After(Node n){
     if(isEmpty())
      throw new ListVazia("Lista vazia");
    return n.GetNext();
  }
  public object replaceElement(Node n, object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    object temp = n.GetElement(); 
    n.SetElement(o);
    return temp;
  }
  public void swapElements(Node n, Node q){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    object a = n.GetElement();
    n.SetElement(q.GetElement());
    q.SetElement(a);
  }
  public Node insertBefore(Node n, object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    Node new_ = new Node(o);
    Node n_before = n.GetPrev();
    new_.SetPrev(n_before);
    new_.SetNext(n);
    n.SetPrev(new_);
    n_before.SetNext(new_);
    size++;
    return new_;
  }
  public Node insertAfter(Node n, object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    Node new_ = new Node(o);
    Node n_next = n.GetNext();
    new_.SetNext(n_next);
    new_.SetPrev(n);
    n_next.SetPrev(new_);
    n.SetNext(new_);
    size++;
    return new_;
  }
  public Node insertFirst(object o){
    Node new_ = new Node(o);
    Node i_next = i.GetNext();
    i.SetNext(new_);
    i_next.SetPrev(new_);
    new_.SetNext(i_next);
    new_.SetPrev(i);
    size++;
    return new_;
  }
  public Node insertLast(object o){
    Node new_ = new Node(o);
    Node f_prev = f.GetPrev();
    new_.SetPrev(f_prev);
    new_.SetNext(f);
    f.SetPrev(new_);
    f_prev.SetNext(new_);
    size++;
    return new_;
  }

  public object Remove(Node n){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    Node n_next = n.GetNext();
    Node n_prev = n.GetPrev();
    n_next.SetPrev(n_prev);
    n_prev.SetNext(n_next);
    object temp = n.GetElement();
    n.SetNext(null);
    n.SetPrev(null);
    n = null;
    size--;
    return temp;
  }
  public Boolean isEmpty(){
    return size==0;
  }
  public int Size(){
    return size;
  }
  public void Ver_Lista_i(){
    Node current = i;
    while(current!=null){
      Console.Write(current.GetElement()+"<->");
      current = current.GetNext();
    }
  }
  public void Ver_Lista_f(){
   Node current = f;
   while(current!=null){
     Console.Write(current.GetElement()+"<->");
     current = current.GetPrev();
   }
  }
}

/*---------- CLASSES DAS EXCEÇÕES ---------*/
public class ListVazia : Exception { 
  public ListVazia(String err){ }
}

/*----------CLASSE NÓ-------------*/
class Node{
  private object element;
  private Node next, prev;
  public Node(object e){
    SetElement(e);
  }
  public void SetElement(object e){
    this.element = e;
  }
  public void SetNext(Node n){
    this.next = n;
  }
  public void SetPrev(Node n){
    this.prev = n;
  }
  public object GetElement(){
    return element;
  }
  public Node GetNext(){
    return next;
  }
  public Node GetPrev(){
    return prev;
  }
}