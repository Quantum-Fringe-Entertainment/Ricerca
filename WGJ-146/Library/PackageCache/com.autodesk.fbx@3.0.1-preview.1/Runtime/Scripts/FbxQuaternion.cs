//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Autodesk.Fbx {

public class FbxQuaternion : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FbxQuaternion(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxQuaternion obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FbxQuaternion() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NativeMethods.delete_FbxQuaternion(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public FbxQuaternion() : this(NativeMethods.new_FbxQuaternion__SWIG_0(), true) {
  }

  public FbxQuaternion(FbxQuaternion pV) : this(NativeMethods.new_FbxQuaternion__SWIG_1(FbxQuaternion.getCPtr(pV)), true) {
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public FbxQuaternion(double pX, double pY, double pZ, double pW) : this(NativeMethods.new_FbxQuaternion__SWIG_2(pX, pY, pZ, pW), true) {
  }

  public FbxQuaternion(double pX, double pY, double pZ) : this(NativeMethods.new_FbxQuaternion__SWIG_3(pX, pY, pZ), true) {
  }

  public FbxQuaternion(FbxVector4 pAxis, double pDegree) : this(NativeMethods.new_FbxQuaternion__SWIG_4(pAxis, pDegree), true) {
  }

  private double GetAtUnchecked(int pIndex) {
    double ret = NativeMethods.FbxQuaternion_GetAtUnchecked(swigCPtr, pIndex);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private void SetAtUnchecked(int pIndex, double pValue) {
    NativeMethods.FbxQuaternion_SetAtUnchecked(swigCPtr, pIndex, pValue);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public void Set(double pX, double pY, double pZ, double pW) {
    NativeMethods.FbxQuaternion_Set__SWIG_0(swigCPtr, pX, pY, pZ, pW);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public void Set(double pX, double pY, double pZ) {
    NativeMethods.FbxQuaternion_Set__SWIG_1(swigCPtr, pX, pY, pZ);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  private FbxQuaternion operator_Add(double pValue) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Add__SWIG_0(swigCPtr, pValue), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private FbxQuaternion operator_Sub(double pValue) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Sub__SWIG_0(swigCPtr, pValue), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private FbxQuaternion operator_Mul(double pValue) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Mul__SWIG_0(swigCPtr, pValue), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private FbxQuaternion operator_Div(double pValue) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Div__SWIG_0(swigCPtr, pValue), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private FbxQuaternion operator_Negate() {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Negate(swigCPtr), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private FbxQuaternion operator_Add(FbxQuaternion pQuaternion) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Add__SWIG_1(swigCPtr, FbxQuaternion.getCPtr(pQuaternion)), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private FbxQuaternion operator_Sub(FbxQuaternion pQuaternion) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Sub__SWIG_1(swigCPtr, FbxQuaternion.getCPtr(pQuaternion)), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private FbxQuaternion operator_Mul(FbxQuaternion pOther) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Mul__SWIG_1(swigCPtr, FbxQuaternion.getCPtr(pOther)), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private FbxQuaternion operator_Div(FbxQuaternion pOther) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_operator_Div__SWIG_1(swigCPtr, FbxQuaternion.getCPtr(pOther)), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxQuaternion Product(FbxQuaternion pOther) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_Product(swigCPtr, FbxQuaternion.getCPtr(pOther)), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public double DotProduct(FbxQuaternion pQuaternion) {
    double ret = NativeMethods.FbxQuaternion_DotProduct(swigCPtr, FbxQuaternion.getCPtr(pQuaternion));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Normalize() {
    NativeMethods.FbxQuaternion_Normalize(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public void Conjugate() {
    NativeMethods.FbxQuaternion_Conjugate(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public double Length() {
    double ret = NativeMethods.FbxQuaternion_Length(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Inverse() {
    NativeMethods.FbxQuaternion_Inverse(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public void SetAxisAngle(FbxVector4 pAxis, double pDegree) {
    NativeMethods.FbxQuaternion_SetAxisAngle(swigCPtr, pAxis, pDegree);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public FbxQuaternion Slerp(FbxQuaternion pOther, double pWeight) {
    FbxQuaternion ret = new FbxQuaternion(NativeMethods.FbxQuaternion_Slerp(swigCPtr, FbxQuaternion.getCPtr(pOther), pWeight), true);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public void ComposeSphericalXYZ(FbxVector4 pEuler) {
    NativeMethods.FbxQuaternion_ComposeSphericalXYZ(swigCPtr, pEuler);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public FbxVector4 DecomposeSphericalXYZ() {
    var ret = NativeMethods.FbxQuaternion_DecomposeSphericalXYZ(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private bool _equals(FbxQuaternion pV) {
    bool ret = NativeMethods.FbxQuaternion__equals(swigCPtr, FbxQuaternion.getCPtr(pV));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public int Compare(FbxQuaternion pQ2, double pThreshold) {
    int ret = NativeMethods.FbxQuaternion_Compare__SWIG_0(swigCPtr, FbxQuaternion.getCPtr(pQ2), pThreshold);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public int Compare(FbxQuaternion pQ2) {
    int ret = NativeMethods.FbxQuaternion_Compare__SWIG_1(swigCPtr, FbxQuaternion.getCPtr(pQ2));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public double GetAt(int index) { return this[index]; }
  public void SetAt(int index, double value) { this[index] = value; }
  public double this[int index] {
    get {
      if (index < 0 || index >= 4) { throw new System.ArgumentOutOfRangeException("index"); }
      return GetAtUnchecked(index);
    }
    set {
      if (index < 0 || index >= 4) { throw new System.ArgumentOutOfRangeException("index"); }
      SetAtUnchecked(index, value);
    }
  }
  public double X { get { return GetAtUnchecked(0); } set { SetAtUnchecked(0, value); } }
  public double Y { get { return GetAtUnchecked(1); } set { SetAtUnchecked(1, value); } }
  public double Z { get { return GetAtUnchecked(2); } set { SetAtUnchecked(2, value); } }
  public double W { get { return GetAtUnchecked(3); } set { SetAtUnchecked(3, value); } }
  
  public static FbxQuaternion operator * (FbxQuaternion a, FbxQuaternion b) {
    return a.operator_Mul(b);
  }

  public static FbxQuaternion operator * (FbxQuaternion a, double b) {
    return a.operator_Mul(b);
  }
  public static FbxQuaternion operator * (double a, FbxQuaternion b) {
    return b.operator_Mul(a);
  }

  public static FbxQuaternion operator / (FbxQuaternion a, FbxQuaternion b) {
    return a.operator_Div(b);
  }

  public static FbxQuaternion operator / (FbxQuaternion a, double b) {
    return a.operator_Div(b);
  }

  public static FbxQuaternion operator + (FbxQuaternion a, FbxQuaternion b) {
    return a.operator_Add(b);
  }

  public static FbxQuaternion operator - (FbxQuaternion a, FbxQuaternion b) {
    return a.operator_Sub(b);
  }

  public static FbxQuaternion operator + (FbxQuaternion a, double b) {
    return a.operator_Add(b);
  }

  public static FbxQuaternion operator - (FbxQuaternion a, double b) {
    return a.operator_Sub(b);
  }

  public static FbxQuaternion operator - (FbxQuaternion a) {
    return a.operator_Negate();
  }

  public bool Equals(FbxQuaternion other) {
    if (object.ReferenceEquals(other, null)) { return false; }
    return _equals(other);
  }

  public override bool Equals(object obj){
    if (object.ReferenceEquals(obj, null)) { return false; }
    /* is obj a subclass of this type; if so use our Equals */
    var typed = obj as FbxQuaternion;
    if (!object.ReferenceEquals(typed, null)) {
      return this.Equals(typed);
    }
    /* are we a subclass of the other type; if so use their Equals */
    if (typeof(FbxQuaternion).IsSubclassOf(obj.GetType())) {
      return obj.Equals(this);
    }
    /* types are unrelated; can't be a match */
    return false;
  }

  public static bool operator == (FbxQuaternion a, FbxQuaternion b) {
    if (object.ReferenceEquals(a, b)) { return true; }
    if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) { return false; }
    return a.Equals(b);
  }

  public static bool operator != (FbxQuaternion a, FbxQuaternion b) {
    return !(a == b);
  }

  public override int GetHashCode() {
    int ret = NativeMethods.FbxQuaternion_GetHashCode(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public override string ToString() {
    return string.Format("<{0},{1},{2},{3}>", X, Y, Z, W);
  }
}

}
