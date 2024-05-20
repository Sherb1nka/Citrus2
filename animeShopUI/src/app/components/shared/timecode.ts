export class TimeCode {
    hours: number = 0;
    minutes: number = 0;
    seconds: number = 0;

    get totalSeconds(): number {
        return this.hours*3600 + this.minutes*60 + this.seconds;
    }
}