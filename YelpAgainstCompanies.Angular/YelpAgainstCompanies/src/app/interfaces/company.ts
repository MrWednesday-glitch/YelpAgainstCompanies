export default interface Company {
    id: number;
    name: string;
    score: number;
    numberOfRatings: number;
    address: string;
    postalCode: string;
    city: string;
    pictureUrl: string | undefined;
}