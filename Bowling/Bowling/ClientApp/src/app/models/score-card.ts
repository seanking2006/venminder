import { ScoreCardFrame } from "./score-card-frame";

export interface ScoreCard {
  score: string;
  gameCompleted: boolean;
  bowlWasValid: boolean;
  errors: string[];
  frames: ScoreCardFrame[];
}
