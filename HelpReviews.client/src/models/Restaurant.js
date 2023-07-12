

export class Restaurant {
  constructor(data) {
    this.id = data.id;
    this.name = data.name;
    this.description = data.description;
    this.category = data.category;
    this.imgUrl = data.imgUrl;
    this.creatorId = data.creatorId;
    this.exposure = data.exposure;
    this.shutdown = data.shutdown;
    this.reportCount = data.reportCount;
  }
}
