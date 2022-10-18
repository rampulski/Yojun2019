using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandala : MonoBehaviour
{
    [SerializeField] private int player;
    [SerializeField] private int seed;
    [SerializeField] private LineRenderer branchPrefab;
    [SerializeField] private float growthSpeed;
    [SerializeField] private float growthWidthReduction;
    [SerializeField] private float startWidth;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;

    private List<LineRenderer> branches;

    private List<(int, Vector3)> buds;
    private List<(int, Vector3)> heads;
    private int[][] currentHeadIndices;
    private int inputCount;
    private int newInputCount;
    private bool[] newPresses;


    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);

        newPresses = new bool[InputManager.instance.inputPlayersPressed.Length];
        for (int i = 0; i < newPresses.Length; i++)
        {
            newPresses[i] = true;
        }
        branches = new List<LineRenderer>();
        buds = new List<(int, Vector3)>();
        heads = new List<(int, Vector3)>();

        AddNewBranch(transform.position, transform.right, startWidth);
        currentHeadIndices = new int[newPresses.Length][];
        for (int i = 0; i < currentHeadIndices.Length; i++)
        {
            currentHeadIndices[i] = new int[2] { 0, 1 };
        }
    }

    // Update is called once per frame
    void Update()
    {
        inputCount = 0;
        newInputCount = 0;
        for (int i = 0; i < InputManager.instance.inputPlayersPressed.Length; i++)
        {
            if (InputManager.instance.inputPlayersPressed[i])
            {
                inputCount++;

                if (newPresses[i])
                {
                    int index = Random.Range(0, heads.Count);
                    (int, Vector3) head = heads[index];
                    LineRenderer lineRenderer = branches[head.Item1];

                    AddNewBranch(lineRenderer.GetPosition(1), Quaternion.Euler(0, 0, Random.Range(minAngle, maxAngle)) * head.Item2, lineRenderer.endWidth);
                    AddNewBranch(lineRenderer.GetPosition(1), Quaternion.Euler(0, 0, -Random.Range(minAngle, maxAngle)) * head.Item2, lineRenderer.endWidth);

                    heads.RemoveAt(index);

                    currentHeadIndices[i][0] = heads.Count - 1;
                    currentHeadIndices[i][1] = heads.Count - 2;
                }
                else
                {
                    LineRenderer lineRenderer = branches[heads[currentHeadIndices[i][0]].Item1];
                    lineRenderer.SetPosition(1, lineRenderer.GetPosition(1) + (heads[currentHeadIndices[i][0]].Item2 * growthSpeed * Time.deltaTime));
                    lineRenderer = branches[heads[currentHeadIndices[i][1]].Item1];
                    lineRenderer.SetPosition(1, lineRenderer.GetPosition(1) + (heads[currentHeadIndices[i][1]].Item2 * growthSpeed * Time.deltaTime));

                    lineRenderer.material.SetColor("_Color", InputManager.instance.GetPlayerColor(i + 1));
                }

                newPresses[i] = false;
            }
            else
            {
                newPresses[i] = true;
            }
        }
    }

    private void AddNewBranch(Vector3 origin, Vector3 direction, float width)
    {
        branches.Add(Instantiate(branchPrefab, origin, Quaternion.identity, transform));

        branches[branches.Count - 1].positionCount = 2;
        branches[branches.Count - 1].SetPosition(0, origin);
        branches[branches.Count - 1].SetPosition(1, origin);

        branches[branches.Count - 1].startWidth = width - growthWidthReduction;
        branches[branches.Count - 1].endWidth = width - growthWidthReduction;

        heads.Add((branches.Count - 1, direction));
    }
}
