using UnityEngine;
using System.Collections;
using DungeonArchitect;
using DungeonArchitect.Utils;
using DungeonArchitect.Builders.Grid;

public class CubicleSelection : SelectorRule {
	public override bool CanSelect(PropSocket socket, Matrix4x4 propTransform, DungeonModel model, System.Random random) {
        var odds = 0.1f;
        var retVal = true;
        if (random.NextFloat() >= odds)
        {
            retVal = false;
            return retVal;
        }
        else if (model is GridDungeonModel)
        {
            var gridModel = model as GridDungeonModel;
            var config = gridModel.Config as GridDungeonConfig;
            var cellSize = config.GridCellSize;

            var position = Matrix.GetTranslation(ref propTransform);
            var gridPositionF = MathUtils.Divide(position, cellSize);
            var gridPosition = MathUtils.ToIntVector(gridPositionF);

            for (int i = -1; i < 1; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    var cellInfo = gridModel.GetGridCellLookup(gridPosition.x + i, gridPosition.z + j);
                    var cell = gridModel.FindCellByPosition(gridPosition);
                    if (!cellInfo.ContainsDoor)
                    {
                        continue;
                    }
                    else
                    {
                        retVal = false;
                        return retVal;
                    }
                }
            }
        }
        return retVal;      
	}
}
