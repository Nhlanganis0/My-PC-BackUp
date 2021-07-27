using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Book))]
public class AutoFlip : MonoBehaviour {
    public FlipMode Mode;
    public float PageFlipTime = 1;
    public float TimeBetweenPages = 1;
    public float DelayBeforeStarting = 0;
    public bool AutoStartFlip=true;
    public Book ControledBook;
    public int AnimationFramesCount = 40;
    bool isFlipping = false;
    public Text textToDelete;
    [SerializeField] UI_Script uI_Script;

    private AudioSource audioSource;
    public AudioClip flipSound;
    public GameObject Video1;
    public GameObject Video2;
    public GameObject Video3;
    public GameObject Video4;
    public GameObject Video5;
    public GameObject Video6;
    public GameObject Video7;
    public GameObject Video8;
    public UI_Script UI_;

    public GameObject text_1;
    public GameObject text_2;
    public GameObject text_3;
    public GameObject text_4;
    public GameObject text_5;
    public GameObject text_6;
    public GameObject text_7;

    // Use this for initialization
    void Start () 
    {
        if (!ControledBook)
            ControledBook = GetComponent<Book>();
        if (AutoStartFlip)
            StartFlipping();
        ControledBook.OnFlip.AddListener(new UnityEngine.Events.UnityAction(PageFlipped));
        audioSource = GetComponent<AudioSource>();

        audioSource = GetComponent<AudioSource>();
        UI_ = UI_.GetComponent<UI_Script>();
	}
    void PageFlipped()
    {
        isFlipping = false;
    }
	public void StartFlipping()
    {
        StartCoroutine(FlipToEnd());
    }
    public void FlipRightPage()
    {
       
        if (isFlipping) return;
        if (ControledBook.currentPage >= ControledBook.TotalPageCount) return;
        isFlipping = true;
        float frameTime = PageFlipTime / AnimationFramesCount;
        float xc = (ControledBook.EndBottomRight.x + ControledBook.EndBottomLeft.x) / 2;
        float xl = ((ControledBook.EndBottomRight.x - ControledBook.EndBottomLeft.x) / 2) * 0.9f;
        //float h =  ControledBook.Height * 0.5f;
        float h = Mathf.Abs(ControledBook.EndBottomRight.y) * 0.9f;
        float dx = (xl)*2 / AnimationFramesCount;
        StartCoroutine(FlipRTL(xc, xl, h, frameTime, dx));
        textToDelete.enabled = false;
        StartCoroutine(enableText());
        audioSource.clip = flipSound;
        audioSource.Play(0);
        if (UI_.directionCount == 0)
        {
            Video1.SetActive(true);
        }
        if (UI_.directionCount == 1)
        {
            Video2.SetActive(true);
            Video1.SetActive(false);
            text_1.SetActive(false);
        }
        if (UI_.directionCount == 2)
        {
            Video3.SetActive(true);
            Video2.SetActive(false);
            text_2.SetActive(false);
        }
        if (UI_.directionCount == 3)
        {
            Video4.SetActive(true);
            Video3.SetActive(false);
            text_3.SetActive(false);
        }
        if (UI_.directionCount == 4)
        {
            Video5.SetActive(true);
            Video4.SetActive(false);
            text_4.SetActive(false);
        }
        if (UI_.directionCount == 5)
        {
            Video6.SetActive(true);
            Video5.SetActive(false);
            text_5.SetActive(false);
        }
        if (UI_.directionCount == 6)
        {
            Video7.SetActive(true);
            Video6.SetActive(false);
            text_6.SetActive(false);
        }
        if (UI_.directionCount == 7)
        {
            Video8.SetActive(true);
            Video7.SetActive(false);
            text_7.SetActive(false);
        }
        if (UI_.directionCount == 8)
        {
            Video8.SetActive(false);
        }
     
    }
    public void FlipLeftPage()
    {
        if (isFlipping) return;
        if (ControledBook.currentPage <= 0) return;
        isFlipping = true;
        float frameTime = PageFlipTime / AnimationFramesCount;
        float xc = (ControledBook.EndBottomRight.x + ControledBook.EndBottomLeft.x) / 2;
        float xl = ((ControledBook.EndBottomRight.x - ControledBook.EndBottomLeft.x) / 2) * 0.9f;
        //float h =  ControledBook.Height * 0.5f;
        float h = Mathf.Abs(ControledBook.EndBottomRight.y) * 0.9f;
        float dx = (xl) * 2 / AnimationFramesCount;
        StartCoroutine(FlipLTR(xc, xl, h, frameTime, dx));
        textToDelete.enabled = false;
        StartCoroutine(enableText());
        audioSource.clip = flipSound;
        audioSource.Play(0);
    }

    IEnumerator enableText()
    {
        yield return new WaitForSeconds(2);
        textToDelete.enabled = true;
    }
    IEnumerator FlipToEnd()
    {
        yield return new WaitForSeconds(DelayBeforeStarting);
        float frameTime = PageFlipTime / AnimationFramesCount;
        float xc = (ControledBook.EndBottomRight.x + ControledBook.EndBottomLeft.x) / 2;
        float xl = ((ControledBook.EndBottomRight.x - ControledBook.EndBottomLeft.x) / 2)*0.9f;
        //float h =  ControledBook.Height * 0.5f;
        float h = Mathf.Abs(ControledBook.EndBottomRight.y)*0.9f;
        //y=-(h/(xl)^2)*(x-xc)^2          
        //               y         
        //               |          
        //               |          
        //               |          
        //_______________|_________________x         
        //              o|o             |
        //           o   |   o          |
        //         o     |     o        | h
        //        o      |      o       |
        //       o------xc-------o      -
        //               |<--xl-->
        //               |
        //               |
        float dx = (xl)*2 / AnimationFramesCount;
        switch (Mode)
        {
            case FlipMode.RightToLeft:
                while (ControledBook.currentPage < ControledBook.TotalPageCount)
                {
                    StartCoroutine(FlipRTL(xc, xl, h, frameTime, dx));
                    yield return new WaitForSeconds(TimeBetweenPages);
                }
                break;
            case FlipMode.LeftToRight:
                while (ControledBook.currentPage > 0)
                {
                    StartCoroutine(FlipLTR(xc, xl, h, frameTime, dx));
                    yield return new WaitForSeconds(TimeBetweenPages);
                }
                break;
        }
    }
    IEnumerator FlipRTL(float xc, float xl, float h, float frameTime, float dx)
    {
        float x = xc + xl;
        float y = (-h / (xl * xl)) * (x - xc) * (x - xc);

        ControledBook.DragRightPageToPoint(new Vector3(x, y, 0));
        for (int i = 0; i < AnimationFramesCount; i++)
        {
            y = (-h / (xl * xl)) * (x - xc) * (x - xc);
            ControledBook.UpdateBookRTLToPoint(new Vector3(x, y, 0));
            yield return new WaitForSeconds(frameTime);
            x -= dx;
        }
        ControledBook.ReleasePage();
    }
    IEnumerator FlipLTR(float xc, float xl, float h, float frameTime, float dx)
    {
        float x = xc - xl;
        float y = (-h / (xl * xl)) * (x - xc) * (x - xc);
        ControledBook.DragLeftPageToPoint(new Vector3(x, y, 0));
        for (int i = 0; i < AnimationFramesCount; i++)
        {
            y = (-h / (xl * xl)) * (x - xc) * (x - xc);
            ControledBook.UpdateBookLTRToPoint(new Vector3(x, y, 0));
            yield return new WaitForSeconds(frameTime);
            x += dx;
        }
        ControledBook.ReleasePage();
    }
}
