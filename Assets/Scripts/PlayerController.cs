// Decompiled with JetBrains decompiler
// Type: PlayerController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B964817-3DD4-4D78-BA3B-791B81C58469
// Assembly location: C:\Users\ctiet\Rollaball\Builds\Rollaball_Data\Managed\Assembly-CSharp.dll

using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
public class PlayerController : MonoBehaviour
{
  private Rigidbody rb;
  private int count;
  private float movementX;
  private float movementY;
  public float speed;
  public TextMeshProUGUI countText;
  public GameObject victoryTextObject;

  private void Start()
  {
    this.rb = this.GetComponent<Rigidbody>();
    this.count = 0;
    this.SetCountText();
    this.victoryTextObject.SetActive(false);
  }

  private void OnMove(InputValue movementValue)
  {
    Vector2 vector2 = movementValue.Get<Vector2>();
    this.movementX = vector2.x;
    this.movementY = vector2.y;
  }

  private void SetCountText()
  {
    this.countText.text = "Count: " + this.count.ToString();
    if (this.count < 5)
      return;
    this.victoryTextObject.SetActive(true);
    Object.Destroy((Object) GameObject.FindGameObjectWithTag("Enemy"));
  }

  private void FixedUpdate()
  {
    this.rb.AddForce(new Vector3(this.movementX, 0.0f, this.movementY) * this.speed);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!other.gameObject.CompareTag("PickUp"))
      return;
    other.gameObject.SetActive(false);
    ++this.count;
    this.SetCountText();
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (!collision.gameObject.CompareTag("Enemy"))
      return;
    Object.Destroy((Object) this.gameObject);
    this.victoryTextObject.gameObject.SetActive(true);
    this.victoryTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
  }
}
