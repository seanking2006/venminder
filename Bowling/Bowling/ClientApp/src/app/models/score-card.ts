import { ScoreCardFrame } from "./score-card-frame";

export interface ScoreCard {
  score: number;
  gameCompleted: boolean;
  bowlWasValid: boolean;
  errors: string[];
  frames: ScoreCardFrame[];
}
