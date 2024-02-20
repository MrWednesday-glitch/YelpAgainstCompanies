export default interface LoginResponse {
    firstName: string;
    lastName: string;
    userName: string;
    role: string;
    accessToken: string;
    refreshToken: string;
}