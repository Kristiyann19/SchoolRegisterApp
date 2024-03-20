export class SearchResultDto<T> {
  totalCount: number;
  items: [T];
}