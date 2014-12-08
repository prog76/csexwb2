////////////////////////////////////////////////////////////////////////////////
// ATL/AUX -- COM/ATL Useful Helpers
// AuxNode.h - CNode - generic double linked node to form a circular list.
// Copyright (c) by Andrew Nosenko (andien@geocities.com), 1997-98
// http://www.geocities.com/~andien/atlaux.htm
//
// The main difference from classic STL/MFC list:
// The object CFoo derives from CTypedNode<CFoo> and participates in the list
// as the body [with m_pNext/m_pPrev], not a reference. This way the object can
// remove itself whenever it wants [with Exclude()], having no knowledge about 
// the list root location.
//
// Virtual entry point [Done()] is provided for the list owner to allow to shutdown 
// a node prematurely. CFoo may override Done() to perform its specific shutdown.
//
// The most natural example of use is a list of polymorphic tasks represented by objects
// (e.g, threads). When the task is done, it removes itself from the list. When the whole 
// proceess is down, it forcedly terminates all objects via Done().
//
// The list may consist of COM objects. There is no need for extra [AddRef] reference 
// for object to participate at the list. But the object should remove itself from the 
// list when its task is over (e.g., download) or upon destruction (i.e., when the last 
// strong reference is gone).

/* Change Log:
1.00.0003
  - CNode::DoneAllNodes added
  - CNODE_NO_VTABLE added
1.00.0002
  - CNode::~CNode for debug purpose
1.00.0001
  - IsEmpty() added.
1.00.0000
  - Created based on my old stuff.
*/

#ifndef _NODE_H
#define _NODE_H

#ifndef CNODE_NO_VTABLE
  #ifdef ATL_NO_VTABLE
    #define CNODE_NO_VTABLE ATL_NO_VTABLE 
  #else
    #define CNODE_NO_VTABLE 
  #endif
#endif

/////////////////////////////////////////////////////////////////////////////
// class CNode is the root of all list elements

class CNODE_NO_VTABLE CNode {
protected:
  CNode* m_pNext;
  CNode* m_pPrev;

public:
  CNode() { Init(); }
  ~CNode();

  // virtual 'door' to allow a shutdown
  virtual void Done() {
    Reset(); }
  void Init() {
    m_pNext = m_pPrev = this; }
  void Reset() {
    Exclude(); Init(); }
  void Exclude();

  CNode* GetNext() const { 
    return m_pNext; }
  CNode* GetPrev() const { 
    return m_pPrev; }
  bool IsEmpty() const {
    return m_pNext == this; }

  CNode* Add(CNode* pNode);
  CNode* AddTail(CNode* pNode);
  CNode* Join(CNode* pNode);
  CNode* JoinTail(CNode* pNode);
  int GetCount() const;
  void DoneAllNodes();
  CNode& operator+(CNode& Node) { 
    return *Add(&Node); }
};

class CStubNode: public CNode {
// no CNODE_NO_VTABLE, has properly layed out vtable
};

/////////////////////////////////////////////////////////////////////////////
// class CNode is the type-safe wrapper class of CNode

template<class Derived>
class CNODE_NO_VTABLE CTypedNode: public CNode {
public:
  typedef CTypedNode _Node;
  // add a node
  Derived* Add(Derived* pNode) { 
    return static_cast<Derived*>(CNode::Add(static_cast<CNode*>(pNode))); }
  Derived* AddTail(Derived* pNode) { 
    return static_cast<Derived*>(CNode::AddTail(static_cast<CNode*>(pNode))); }
  // join another whole list
  Derived* Join(Derived* pNode) { 
    return static_cast<Derived*>(CNode::Join(static_cast<CNode*>(pNode))); }
  Derived* JoinTail(Derived* pNode) { 
    return static_cast<Derived*>(CNode::JoinTail(static_cast<CNode*>(pNode))); }
  Derived* GetNext() const { 
    return static_cast<Derived*>(CNode::GetNext()); }
  Derived* GetPrev() const { 
    return static_cast<Derived*>(CNode::GetPrev()); }
  Derived& operator+=(Derived& Node) { 
    return *Add(&Node); }
  bool IsRoot(const Derived* pNode) const { 
    return static_cast<const CNode*>(pNode) == this; }
};

template<class Node>
class CNODE_NO_VTABLE CTypedList: public CTypedNode<Node> {
public:
  ~CTypedList() {
    while ( !IsEmpty() )
      delete static_cast<Node*>(CNode::GetNext());
  }
};

/////////////////////////////////////////////////////////////////////////////
// CNode's inlines

inline CNode::~CNode() {
  _ASSERTE(m_pNext == m_pPrev && (m_pNext == this || m_pNext == (CNode*)0xFEFEABCD));
  // if assertion occurred, you forgot
  // to exclude the object form the list
}

inline CNode* CNode::Add(CNode* pNode) {
  pNode->m_pNext = m_pNext;
  m_pNext = m_pNext->m_pPrev = pNode;
  return pNode->m_pPrev = this;
}

inline CNode* CNode::AddTail(CNode* pNode) {
  pNode->m_pPrev = m_pPrev;
  m_pPrev = m_pPrev->m_pNext = pNode;
  return pNode->m_pNext = this;
}

inline CNode* CNode::Join(CNode* pNode) {
  CNode* p = pNode->m_pPrev;
  m_pNext->m_pPrev = p;
  p->m_pNext = m_pNext;
  m_pNext = pNode;
  return pNode->m_pPrev = this;
}

inline CNode* CNode::JoinTail(CNode* pNode) {
  CNode* p = pNode->m_pPrev;
  m_pPrev->m_pNext = pNode;
  pNode->m_pPrev = m_pPrev;
  m_pPrev = p;
  return p->m_pNext = this;
}

inline void CNode::Exclude() { 
  m_pNext->m_pPrev = m_pPrev;
  m_pPrev->m_pNext = m_pNext;
#ifdef _DEBUG
  m_pNext = m_pPrev = (CNode*)0xFEFEABCD;
#endif
}

inline int CNode::GetCount() const {
  int c = -1;
  const CNode* pNode = this;
  do c++; 
  while ( (pNode = pNode->GetNext()) != this );
  return c;
}

inline void CNode::DoneAllNodes() {
  while ( !IsEmpty() )
    GetNext()->Done();
}

#endif //_NODE_H
