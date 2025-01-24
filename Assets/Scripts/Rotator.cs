// Decompiled with JetBrains decompiler
// Type: Rotator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B964817-3DD4-4D78-BA3B-791B81C58469
// Assembly location: C:\Users\ctiet\Rollaball\Builds\Rollaball_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Rotator : MonoBehaviour
{
  private void Update() => this.transform.Rotate(new Vector3(15f, 30f, 45f) * Time.deltaTime);
}
