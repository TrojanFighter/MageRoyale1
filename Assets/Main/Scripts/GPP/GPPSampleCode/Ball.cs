using MageRoyale.Services;
using UnityEngine;
using MageRoyale.Services.Task;

namespace GPP
{

    public class Ball : MonoBehaviour
    {
        //private readonly TaskManager _tm = new TaskManager();

        private void Start()
        {
            DoMyThing();
        }

        private void DoMyThing()
        {
            // Just setting up some variables so the task constructors below are a little easier to read...
            var startPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 10));
            var endPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 10));
            var midPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));

            var startScale = Vector3.one;
            var endScale = startScale * 2;

            // Teleport to the left of the screen immediately...
            ServiceList.TaskManager.Do(new SetPosTask(gameObject, startPos))

                // Move to the middle over half a second...
                .Then(new MoveTask(gameObject, startPos, midPos, 0.5f))

                // Then scale up for one quarter of a second
                .Then(new MoveTask(gameObject, startScale, endScale, 0.25f))

                .Then(new ScaleTask(gameObject, endScale, endScale + new Vector3(2, 0, 0), 0.25f))

                .Then(new RotateTask(gameObject, Vector3.zero, new Vector3(0, 0, 180), 0.5f))

                .Then(new ScaleTask(gameObject, endScale + new Vector3(2, 0, 0), endScale, 0.25f))

                // Then scale down for one quarter of a second
                .Then(new ScaleTask(gameObject, endScale, startScale, 0.25f))

                // Then move off screen over half a second
                .Then(new MoveTask(gameObject, midPos, endPos, 0.25f))

                // Then reset the whole thing
                .Then(new ActionTask(DoMyThing));
        }

    }
}





