// Decompiled with JetBrains decompiler
// Type: CameraController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B964817-3DD4-4D78-BA3B-791B81C58469
// Assembly location: C:\Users\ctiet\Rollaball\Builds\Rollaball_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CameraController : MonoBehaviour
{
  public GameObject player;
  private Vector3 offset;

  private void Start() => this.offset = this.transform.position - this.player.transform.position;

  private void LateUpdate()
  {
    this.transform.position = this.player.transform.position + this.offset;
  }
}
