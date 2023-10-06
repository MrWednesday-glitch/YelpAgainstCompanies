export default interface Company {
    name: string;
    score: number;
    numberOfRatings: number;
    address: string;
    postalCode: string;
    city: string;
    pictureUrl: string | undefined;
}