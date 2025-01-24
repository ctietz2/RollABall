// Decompiled with JetBrains decompiler
// Type: EnemyMovement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B964817-3DD4-4D78-BA3B-791B81C58469
// Assembly location: C:\Users\ctiet\Rollaball\Builds\Rollaball_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class EnemyMovement : MonoBehaviour
{
  public Transform player;
  private NavMeshAgent navMeshAgent;

  private void Start() => this.navMeshAgent = this.GetComponent<NavMeshAgent>();

  private void Update()
  {
    if (!((Object) this.player != (Object) null))
      return;
    this.navMeshAgent.SetDestination(this.player.position);
  }
}
