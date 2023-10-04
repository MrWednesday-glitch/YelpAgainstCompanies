import Rating from "./rating";

export default interface Company {
    name: string;
    score: number;
    ratings: Rating[];
}