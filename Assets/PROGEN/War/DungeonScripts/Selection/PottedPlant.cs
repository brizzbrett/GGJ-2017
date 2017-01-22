using UnityEngine;
using System.Collections;
using DungeonArchitect;
using DungeonArchitect.Utils;
using DungeonArchitect.Builders.Grid;

public class PottedPlant : SelectorRule {
	public override bool CanSelect(PropSocket socket, Matrix4x4 propTransform, DungeonModel model, System.Random random) {
        if (model is GridDungeonModel)
        {
            var gridModel = model as GridDungeonModel;
            var config = gridModel.Config as GridDungeonConfig;
            var cellSize = config.GridCellSize;

            var position = Matrix.GetTranslation(ref propTransform);
            var gridPositionF = MathUtils.Divide(position, cellSize);
            var gridPosition = MathUtils.ToIntVector(gridPositionF);
            var cellInfo = gridModel.GetGridCellLookup(gridPosition.x, gridPosition.z);
            var cell = gridModel.FindCellByPosition(gridPosition);
            if (!cellInfo.ContainsDoor)
            {
                return (socket.gridPosition.x + socket.gridPosition.z) % 6 == 0;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
               
	}
}



