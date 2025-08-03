using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Datas
    [Header("CharacterProperties")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("References")]
    [SerializeField] private InputActionReference movementInputs;
    [SerializeField] private InputActionReference jumpInputs;
    [SerializeField] private Animator animator;

    [Header("Components")]
    [SerializeField] Rigidbody rb;
    private IState currentState;

    [Header("Variables")]
    [SerializeField] private float fallMultiplier;  //  Yerçekiminin karakter üzerinde ki etkisi.
    private Vector3 moveDirection;
    public bool isJumping;
    public bool isGrounded;
    public bool isWalking;
    #endregion

    private void Start()
    {
        movementInputs.action.Enable();
        jumpInputs.action.Enable();

        currentState = new Idle_State();        // İlk durumumuz Idle olacağı için startta bu atamayı yapıyoruz.
        currentState.Enter(this);               // Sonra da Idle durumununa girdiğimize çalışacak fonksiyonu çalıştırıyoruz.
    }

    private void Update()
    {
        moveDirection = movementInputs.action.ReadValue<Vector3>();
        isJumping = jumpInputs.action.IsPressed();

        currentState.Update(this);              // Güncel durumda ki Update fonksiyonunda ne varsa onu çalıştırıyoruz.
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    #region Functions

    public void ChangeState(IState newState)           // Durum değiştirme fonksiyonu
    {
        currentState.Exit(this);                // Güncel durumun çıkışında hangi fonksiyonlar yapılacaksa onu yap.
        currentState = newState;                // Durumu güncelle
        currentState.Enter(this);               // Güncellenen yeni durumun giriş fonksiyonları ne ise onları yap.
    }

    private void Walk()
    {
        rb.linearVelocity = moveDirection * speed;
        isWalking = moveDirection != Vector3.zero;
        animator.SetBool("isWalking", isWalking);
    }

    private void Jump()
    {
        if (isJumping)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        else
        {
            isGrounded = true;
        }
    }
    
    #endregion

}
